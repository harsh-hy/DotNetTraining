public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}
public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();    
    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        if(product==null)
            throw new ArgumentNullException(nameof(product));
        // Rule: Product ID must be unique
        if(product.Id<=0 || _products.Any(p => p.Id == product.Id))
            throw new ArgumentException("ID must be Unique");
        // Rule: Price must be positive
        if(product.Price<=0)
            throw new ArgumentException("Price must be Positive");
        // Rule: Name cannot be null or empty
        if(string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Name cannot be null or Empty String!");
        // Add to collection if validation passes
        _products.Add(product);
    }
    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        if(predicate == null)
            throw new ArgumentNullException(nameof(predicate));
        return _products.Where(predicate);
    }
    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        return _products.Sum(p => p.Price);
    }
}
// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Create a discounted product wrapper 
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;
    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        _product = product ?? throw new ArgumentNullException(nameof(product));
        if(discountPercentage<0 || discountPercentage>100)
            throw new ArgumentOutOfRangeException(nameof(discountPercentage),"Discount must be between 0 and 100.");
        _discountPercentage=discountPercentage;
    }
    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
    // TODO: Override ToString to show discount details
    public override string ToString()
    {
        return $"{_product.Name}" +$"Discount: {_discountPercentage}% FinalPrice:{DiscountedPrice:C}";
    }
}
// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        if (products == null)
            throw new ArgumentNullException(nameof(products));
        // a) Print all product names and prices
        var productList = products.ToList();
        foreach(var p in productList)
        {
            Console.WriteLine($"Product: {p.Name} Price: {p.Price}");
        }
        // b) Find the most expensive product
        var mostExpen=productList.OrderByDescending(p => p.Price).FirstOrDefault();
        // c) Group products by category
        var grouped = productList.GroupBy(p => p.Category);
        foreach(var group in grouped)
        {
            Console.WriteLine("Category: "+group.Key);
            foreach( var p in group)
                Console.WriteLine($"  -{p.Name}");
        }
        // d) Apply 10% discount to Electronics over $500
        var discounted = productList
                        .Where(p => p.Category == Category.Electronics && p.Price > 500)
                        .Select(p => new DiscountedProduct<T>(p, 10));
    }
    
    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) 
        where T : IProduct
    {
        foreach (var product in products)
        {
            var newPrice = priceAdjuster(product);
            if (newPrice <= 0)
                continue;
            var priceProperty = product.GetType().GetProperty("Price");
            if (priceProperty != null && priceProperty.CanWrite)
            {
                priceProperty.SetValue(product, newPrice);
            }
        }
    }
}


// 5. TEST SCENARIO: Your tasks:
// a) Implement all TODO methods with proper error handling
// b) Create a sample inventory with at least 5 products
// c) Demonstrate:
//    - Adding products with validation
//    - Finding products by brand (for electronics)
//    - Applying discounts
//    - Calculating total value before/after discount
//    - Handling a mixed collection of different product types
public class Program
{
    public static void Main()
    {
        var repo = new ProductRepository<ElectronicProduct>();
        var p1 = new ElectronicProduct
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200,
            Brand = "Dell",
            WarrantyMonths = 24
        };
        var p2 = new ElectronicProduct
        {
            Id = 2,
            Name = "Smartphone",
            Price = 800,
            Brand = "Samsung",
            WarrantyMonths = 12
        };
        var p3 = new ElectronicProduct
        {
            Id = 3,
            Name = "Headphones",
            Price = 150,
            Brand = "Sony",
            WarrantyMonths = 6
        };
        var p4 = new ElectronicProduct
        {
            Id = 4,
            Name = "TV",
            Price = 2000,
            Brand = "LG",
            WarrantyMonths = 36
        };
        var p5 = new ElectronicProduct
        {
            Id = 5,
            Name = "Keyboard",
            Price = 100,
            Brand = "Logitech",
            WarrantyMonths = 12
        };
        repo.AddProduct(p1);
        repo.AddProduct(p2);
        repo.AddProduct(p3);
        repo.AddProduct(p4);
        repo.AddProduct(p5);
        var sonyProducts = repo.FindProducts(p => p.Brand == "Sony");
        Console.WriteLine("Sony Products:");
        foreach (var p in sonyProducts)
            Console.WriteLine(p.Name);
        var totalBefore = repo.CalculateTotalValue();
        Console.WriteLine($"Total Inventory Value (Before): {totalBefore}");
        var discounted = repo.FindProducts(p => p.Price > 500)
                        .Select(p => new DiscountedProduct<ElectronicProduct>(p, 10));
        Console.WriteLine("Discounted Products:");
        foreach (var d in discounted)
            Console.WriteLine(d);
        var manager = new InventoryManager();
        manager.ProcessProducts(new List<ElectronicProduct>
        {
            p1, p2, p3, p4, p5
        });
        manager.UpdatePrices(
            new List<ElectronicProduct> { p1, p2, p3, p4, p5 },
            p => p.Price * 1.05m
        );
        var totalAfter = repo.CalculateTotalValue();
        Console.WriteLine($"Total Inventory Value (After): {totalAfter}");
    }
}