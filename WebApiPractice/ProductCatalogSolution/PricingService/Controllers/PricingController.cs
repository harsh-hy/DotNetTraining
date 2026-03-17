using Microsoft.AspNetCore.Mvc;
using PricingService.Models;

namespace PricingService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PricingController : ControllerBase
{
    private static List<Price> prices = new()
{
new Price { ProductId = 1, Amount = 75000 },
new Price { ProductId = 2, Amount = 50000 },
new Price { ProductId = 3, Amount = 3000 }
};

    [HttpGet("{productId}")]
    public IActionResult GetPrice(int productId)
    {
        var price = prices.FirstOrDefault(x => x.ProductId == productId);
        if (price == null) return NotFound();
        return Ok(price);
    }
}