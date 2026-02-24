using FlexibleInventorySystem_Practice.Interfaces;
using FlexibleInventorySystem_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Services
{  
    public class InventoryManager : IInventoryOperations, IReportGenerator
    {
        private readonly List<Product> _products;
        private readonly object _lockObject = new object();

        public InventoryManager()
        {
            _products = new List<Product>();
        }

        public bool AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product FindProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public string GenerateCategorySummary()
        {
            throw new NotImplementedException();
        }

        public string GenerateExpiryReport(int daysThreshold)
        {
            throw new NotImplementedException();
        }

        public string GenerateInventoryReport()
        {
            throw new NotImplementedException();
        }

        public string GenerateValueReport()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalInventoryValue()
        {
            throw new NotImplementedException();
        }

        public bool RemoveProduct(string productId)
        {
            throw new NotImplementedException();
        }

        // Implement all interface methods here

        // Additional methods for bonus features
        public IEnumerable<Product> SearchProducts(Func<Product, bool> predicate)
        {
            return _products.Where(predicate);
        }

        public bool UpdateQuantity(string productId, int newQuantity)
        {
            throw new NotImplementedException();
        }

        
    }    
}
