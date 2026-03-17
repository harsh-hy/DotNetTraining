using Microsoft.AspNetCore.Mvc;
using InventoryService.Models;

namespace InventoryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private static List<Inventory> inventory = new()
{
new Inventory { ProductId = 1, Stock = 10 },
new Inventory { ProductId = 2, Stock = 5 },
new Inventory { ProductId = 3, Stock = 20 }
};

    [HttpGet("{productId}")]
    public IActionResult GetStock(int productId)
    {
        var stock = inventory.FirstOrDefault(x => x.ProductId == productId);
        if (stock == null) return NotFound();
        return Ok(stock);
    }
}