using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace top5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class top5cont : Controller
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "A", Price = 100 },
            new Product { Id = 2, Name = "B", Price = 500 },
            new Product { Id = 3, Name = "C", Price = 300 },
            new Product { Id = 4, Name = "D", Price = 800 },
            new Product { Id = 5, Name = "E", Price = 200 },
            new Product { Id = 6, Name = "F", Price = 900 },
            new Product { Id = 7, Name = "G", Price = 50 }
        };
        [HttpGet("top5-expensive")]
        public IActionResult GetTop5()
        {
            var top5 = products
                        .OrderByDescending(p => p.Price).Take(5).ToList();
            return Ok(top5);
        }
    }
}
