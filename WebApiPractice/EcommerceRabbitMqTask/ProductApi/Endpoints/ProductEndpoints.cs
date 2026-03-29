using ProductApi.Messaging;
using ProductApi.Models;
using ProductApi.Models.Contracts;
using ProductApi.Services;

namespace ProductApi.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/products", (Product product, ProductService productService) =>
        {
            if (product.Id <= 0 || string.IsNullOrWhiteSpace(product.Name) || product.Price < 0)
            {
                return Results.BadRequest("Provide valid product Id, Name, and non-negative Price.");
            }

            var created = productService.Create(product);
            return Results.Created($"/products/{created.Id}", created);
        });

        app.MapGet("/products", (ProductService productService) => Results.Ok(productService.GetAll()));

        app.MapGet("/products/{id:int}", (int id, ProductService productService) =>
        {
            var product = productService.GetById(id);
            return product is null ? Results.NotFound() : Results.Ok(product);
        });

        app.MapPut("/products/{id:int}/price", (int id, UpdatePriceRequest request, ProductService productService) =>
        {
            if (request.Price < 0)
            {
                return Results.BadRequest("Price cannot be negative.");
            }

            var updated = productService.UpdatePrice(id, request.Price);
            return updated ? Results.NoContent() : Results.NotFound();
        });

        app.MapPost("/products/{id:int}/select", (
            int id,
            ProductSelectionRequest request,
            ProductService productService,
            ProductEventPublisher publisher) =>
        {
            var product = productService.GetById(id);
            if (product is null)
            {
                return Results.NotFound();
            }

            if (request.Quantity <= 0)
            {
                return Results.BadRequest("Quantity must be greater than zero.");
            }

            var message = new ProductSelected
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = request.Quantity,
                SelectedAtUtc = DateTime.Now
            };

            publisher.PublishProductSelected(message);
            return Results.Accepted($"/products/{id}", message);
        });

        app.MapPost("/products/select", (
            BulkProductSelectionRequest request,
            ProductService productService,
            ProductEventPublisher publisher) =>
        {
            if (request.Items is null || request.Items.Count == 0)
            {
                return Results.BadRequest("At least one product selection item is required.");
            }

            var invalidItems = request.Items
                .Where(item => item.ProductId <= 0 || item.Quantity <= 0)
                .ToList();

            if (invalidItems.Count > 0)
            {
                return Results.BadRequest("Each item must have ProductId > 0 and Quantity > 0.");
            }

            var missingProductIds = request.Items
                .Select(item => item.ProductId)
                .Distinct()
                .Where(id => productService.GetById(id) is null)
                .ToList();

            if (missingProductIds.Count > 0)
            {
                return Results.BadRequest(new
                {
                    Message = "Some products were not found.",
                    MissingProductIds = missingProductIds
                });
            }

            var messages = new List<ProductSelected>();

            foreach (var item in request.Items)
            {
                var product = productService.GetById(item.ProductId)!;

                var message = new ProductSelected
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = item.Quantity,
                    SelectedAtUtc = DateTime.Now
                };

                publisher.PublishProductSelected(message);
                messages.Add(message);
            }

            return Results.Accepted("/products/select", messages);
        });

        return app;
    }
}
