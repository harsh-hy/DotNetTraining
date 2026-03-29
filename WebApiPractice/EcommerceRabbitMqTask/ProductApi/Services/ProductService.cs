using System.Collections.Concurrent;
using ProductApi.Models;

namespace ProductApi.Services;

public class ProductService
{
    private readonly ConcurrentDictionary<int, Product> _products = new();

    private static readonly Product[] DummyProducts =
    [
        new() { Id = 1, Name = "Amul Butter 500g", Price = 285m },
        new() { Id = 2, Name = "Aashirvaad Atta 5kg", Price = 289m },
        new() { Id = 3, Name = "Tata Salt 1kg", Price = 30m },
        new() { Id = 4, Name = "Daawat Basmati Rice 5kg", Price = 699m },
        new() { Id = 5, Name = "Parle-G Biscuits Family Pack", Price = 60m },
        new() { Id = 6, Name = "Haldiram Bhujia 400g", Price = 145m },
        new() { Id = 7, Name = "Dabur Honey 500g", Price = 235m },
        new() { Id = 8, Name = "Bru Instant Coffee 200g", Price = 365m },
        new() { Id = 9, Name = "Fortune Sunflower Oil 1L", Price = 165m },
        new() { Id = 10, Name = "Kissan Mixed Fruit Jam 500g", Price = 210m }
    ];

    public ProductService()
    {
        foreach (var product in DummyProducts)
        {
            _products[product.Id] = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }

    public Product Create(Product product)
    {
        _products[product.Id] = product;
        return product;
    }

    public IReadOnlyCollection<Product> GetAll()
    {
        return _products.Values.OrderBy(p => p.Id).ToList();
    }

    public Product? GetById(int id)
    {
        return _products.TryGetValue(id, out var product) ? product : null;
    }

    public bool UpdatePrice(int id, decimal price)
    {
        if (!_products.TryGetValue(id, out var product))
        {
            return false;
        }

        product.Price = price;
        return true;
    }
}
