namespace ProductApi.Models;

public class BulkProductSelectionRequest
{
    public List<BulkProductSelectionItem> Items { get; set; } = [];
}

public class BulkProductSelectionItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; } = 1;
}
