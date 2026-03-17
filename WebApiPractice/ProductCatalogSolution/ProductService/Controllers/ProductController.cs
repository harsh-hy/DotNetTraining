using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> products = new()
    {
        new Product { Id = 1, Name = "Laptop", CategoryId = 1 },
        new Product { Id = 2, Name = "Phone", CategoryId = 1 },
        new Product { Id = 3, Name = "Shoes", CategoryId = 2 }
    };

    private readonly HttpClient _httpClient;

    public ProductController(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetProductDetails(int id)
    {
        var product = products.FirstOrDefault(x => x.Id == id);
        if (product == null) return NotFound();

        var price = await _httpClient.GetFromJsonAsync<PriceDto>(
            $"https://localhost:7004/api/pricing/{id}");

        var stock = await _httpClient.GetFromJsonAsync<InventoryDto>(
            $"https://localhost:7003/api/inventory/{id}");

        if (price == null || stock == null)
            return NotFound();

        var result = new ProductDetailsDto
        {
            Id = product.Id,
            Name = product.Name,
            CategoryId = product.CategoryId,
            Price = price.Amount,
            Stock = stock.Stock
        };

        return Ok(result);
    }
}