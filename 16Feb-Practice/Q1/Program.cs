using System;
using System.Collections.Generic;
using System.Linq;
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}
public enum Category { Electronics, Clothing, Books, Groceries }
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();
    public void AddProduct(T product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (string.IsNullOrWhiteSpace(product.Name)) throw new Exception("Name cannot be empty");
        if (product.Price <= 0) throw new Exception("Price must be positive");
        if (_products.Any(p => p.Id == product.Id)) throw new Exception("Duplicate product Id");
        _products.Add(product);
    }
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        return _products.Where(predicate);
    }
    public decimal CalculateTotalValue()
    {
        return _products.Sum(p => p.Price);
    }
    public List<T> GetAll()
    {
        return _products;
    }
}
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;
    public DiscountedProduct(T product, decimal discountPercentage)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (discountPercentage < 0 || discountPercentage > 100) throw new Exception("Invalid discount");
        _product = product;
        _discountPercentage = discountPercentage;
    }
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
    public override string ToString()
    {
        return $"{_product.Name} | Original:{_product.Price} | Discount:{_discountPercentage}% | Final:{DiscountedPrice}";
    }
}
public class InventoryManager
{
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        Console.WriteLine("\n--- Product List ---");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - {p.Price}");
        var expensive = products.OrderByDescending(p => p.Price).FirstOrDefault();
        if (expensive != null)
            Console.WriteLine($"\nMost Expensive: {expensive.Name} ({expensive.Price})");
        Console.WriteLine("\n--- Grouped By Category ---");
        var groups = products.GroupBy(p => p.Category);
        foreach (var g in groups)
        {
            Console.WriteLine(g.Key);
            foreach (var item in g)
                Console.WriteLine(" " + item.Name);
        }
        Console.WriteLine("\n--- Electronics Discount Applied ---");
        foreach (var p in products.Where(x => x.Category == Category.Electronics && x.Price > 500))
        {
            var dp = new DiscountedProduct<T>(p, 10);
            Console.WriteLine(dp.ToString());
        }
    }
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) where T : IProduct
    {
        foreach (var p in products)
        {
            try
            {
                decimal newPrice = priceAdjuster(p);
                if (p is ElectronicProduct ep)
                    ep.Price = newPrice;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Price update failed for {p.Name}: {ex.Message}");
            }
        }
    }
}
public class Program
{
    public static void Main()
    {
        var repo = new ProductRepository<ElectronicProduct>();
        repo.AddProduct(new ElectronicProduct { Id = 1, Name = "Laptop", Price = 1200, Brand = "Dell", WarrantyMonths = 24 });
        repo.AddProduct(new ElectronicProduct { Id = 2, Name = "Headphones", Price = 150, Brand = "Sony", WarrantyMonths = 12 });
        repo.AddProduct(new ElectronicProduct { Id = 3, Name = "Smartphone", Price = 800, Brand = "Samsung", WarrantyMonths = 18 });
        Console.WriteLine("Total Inventory Value: " + repo.CalculateTotalValue());
        var filtered = repo.FindProducts(p => p.Price > 500);
        Console.WriteLine("\nFiltered (>500):");
        foreach (var f in filtered)
            Console.WriteLine(f.Name);
        var manager = new InventoryManager();
        manager.ProcessProducts(repo.GetAll());
        manager.UpdatePrices(repo.GetAll(), p => p.Price * 1.05m);
        Console.WriteLine("\nAfter 5% Price Increase:");
        foreach (var p in repo.GetAll())
            Console.WriteLine($"{p.Name} - {p.Price}");
    }
}
