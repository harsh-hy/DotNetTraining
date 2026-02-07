using System;
using Application;

namespace Presentation;

class Program
{
    static void Main()
    {
        InventoryManager manager = new InventoryManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Product");
            Console.WriteLine("2. Display Products Grouped by Category");
            Console.WriteLine("3. Update Stock (After Sale)");
            Console.WriteLine("4. Find Products Below Price");
            Console.WriteLine("5. Show Category Stock Summary");
            Console.WriteLine("6. Exit");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Product Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Category (Electronics/Clothing/Books): ");
                    string category = Console.ReadLine();

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Stock Quantity: ");
                    int stock = int.Parse(Console.ReadLine());

                    manager.AddProduct(name, category, price, stock);
                    Console.WriteLine("Product added successfully.");
                    break;

                case "2":
                    var grouped = manager.GroupProductsByCategory();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nCategory: {g.Key}");
                        foreach (var p in g.Value)
                        {
                            Console.WriteLine($"{p.ProductCode} - {p.ProductName} - ₹{p.Price} (Stock: {p.StockQuantity})");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Enter Product Code: ");
                    string code = Console.ReadLine();

                    Console.Write("Quantity Sold: ");
                    int qty = int.Parse(Console.ReadLine());

                    if (!manager.UpdateStock(code, qty))
                        Console.WriteLine("Insufficient stock or invalid product code.");
                    else
                        Console.WriteLine("Stock updated successfully.");
                    break;

                case "4":
                    Console.Write("Enter Maximum Price: ");
                    double maxPrice = double.Parse(Console.ReadLine());

                    var products = manager.GetProductsBelowPrice(maxPrice);
                    foreach (var p in products)
                    {
                        Console.WriteLine($"{p.ProductCode} - {p.ProductName} - ₹{p.Price}");
                    }
                    break;

                case "5":
                    var summary = manager.GetCategoryStockSummary();
                    foreach (var s in summary)
                    {
                        Console.WriteLine($"{s.Key}: Total Stock = {s.Value}");
                    }
                    break;

                case "6":
                    return;
            }
        }
    }
}
