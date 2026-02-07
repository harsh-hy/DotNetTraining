using System;
using System.Collections.Generic;
class Product
{
    public int Id;
    public string Name;
    public decimal Price;
}
class RowError
{
    public int RowNumber;
    public string Reason;
}
class ImportResult
{
    public int InsertedCount;
    public List<RowError> Errors = new List<RowError>();
}
class CsvImporter
{
    public static ImportResult ImportProducts(string csvPath)
    {
        ImportResult result = new ImportResult();
        int rowNumber = 0;
        foreach (string line in File.ReadLines(csvPath))
        {
            rowNumber++;
            if (string.IsNullOrWhiteSpace(line))
            {
                result.Errors.Add(new RowError { RowNumber = rowNumber, Reason = "Empty row" });
                continue;
            }
            string[] parts = line.Split(',');
            if (parts.Length != 3)
            {
                result.Errors.Add(new RowError { RowNumber = rowNumber, Reason = "Invalid column count" });
                continue;
            }
            if (!int.TryParse(parts[0], out int id))
            {
                result.Errors.Add(new RowError { RowNumber = rowNumber, Reason = "Invalid Id" });
                continue;
            }
            if (string.IsNullOrWhiteSpace(parts[1]))
            {
                result.Errors.Add(new RowError { RowNumber = rowNumber, Reason = "Name missing" });
                continue;
            }
            if (!decimal.TryParse(parts[2], out decimal price) || price < 0)
            {
                result.Errors.Add(new RowError { RowNumber = rowNumber, Reason = "Invalid price" });
                continue;
            }
            Product product = new Product
            {
                Id = id,
                Name = parts[1],
                Price = price
            };
            result.InsertedCount++;
        }
        return result;
    }
    public static void Main()
    {
        ImportResult result = ImportProducts("products.csv");
        Console.WriteLine("Inserted: " + result.InsertedCount);
        foreach (var error in result.Errors)
        {
            Console.WriteLine("Row " + error.RowNumber + ": " + error.Reason);
        }
    }
}
