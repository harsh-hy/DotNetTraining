using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application;
public class InventoryManager
{
    private List<Product> products = new List<Product>();
    private int productCounter = 0;
    public void AddProduct(string name, string category, double price, int stock)
    {
        productCounter++;

        products.Add(new Product
        {
            ProductCode = $"P{productCounter:D3}",
            ProductName = name,
            Category = category,
            Price = price,
            StockQuantity = stock
        });
    }
    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        return new SortedDictionary<string, List<Product>>(
            products.GroupBy(p => p.Category)
                    .ToDictionary(g => g.Key, g => g.ToList())
        );
    }
    public bool UpdateStock(string productCode, int quantity)
    {
        Product product = products.FirstOrDefault(p => p.ProductCode == productCode);
        if (product == null || product.StockQuantity < quantity)
            return false;
        product.StockQuantity -= quantity;
        return true;
    }
    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        return products
            .Where(p => p.Price < maxPrice)
            .ToList();
    }
    public Dictionary<string, int> GetCategoryStockSummary()
    {
        return products
            .GroupBy(p => p.Category)
            .ToDictionary(g => g.Key, g => g.Sum(p => p.StockQuantity));
    }
}
