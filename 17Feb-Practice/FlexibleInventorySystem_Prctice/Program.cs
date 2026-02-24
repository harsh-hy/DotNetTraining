using System;
using FlexibleInventorySystem_Practice.Services;
using FlexibleInventorySystem_Practice.Models;


namespace FlexibleInventorySystem_Practice
{
    /// <summary>
    /// TODO: Implement console user interface
    /// </summary>
    class Program
    {
        private static InventoryManager _inventory = new InventoryManager();

        static void Main(string[] args)
        {
            // TODO: Display menu and handle user input
            // Options should include:
            // 1. Add Product
            // 2. Remove Product
            // 3. Update Quantity
            // 4. Find Product
            // 5. View All Products
            // 6. Generate Reports
            // 7. Check Low Stock
            // 8. Exit

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProductMenu();
                        break;
                    case "2":
                        RemoveProductMenu();
                        break;
                    // TODO: Implement other cases
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            // TODO: Display formatted menu
            throw new NotImplementedException();
        }

        static void AddProductMenu()
        {
            // TODO: Implement menu to add different product types
            // Ask user for product type
            // Collect appropriate properties
            // Add to inventory
            throw new NotImplementedException();
        }

        static void RemoveProductMenu()
        {
            // TODO: Implement product removal
            throw new NotImplementedException();
        }

        // TODO: Add other menu methods
    }
}