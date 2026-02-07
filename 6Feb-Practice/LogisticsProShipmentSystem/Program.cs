using System;
using System.Collections.Generic;
using System.Linq;

public class Shipment
{
    public string ShipmentCode { get; set; }
    public string TransportMode { get; set; }
    public double Weight { get; set; }
    public int StorageDays { get; set; }
}
public class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        if (ShipmentCode.Length != 7)
            return false;
        if (!ShipmentCode.StartsWith("GC#"))
            return false;
        return ShipmentCode.Substring(3).All(char.IsDigit);
    }
    public double CalculateTotalCost()
    {
        double ratePerKg = 0;
        if (TransportMode == "Sea")
            ratePerKg = 15.00;
        else if (TransportMode == "Air")
            ratePerKg = 50.00;
        else if (TransportMode == "Land")
            ratePerKg = 25.00;
        double totalCost = (Weight * ratePerKg) + Math.Sqrt(StorageDays);
        return Math.Round(totalCost, 2);
    }
}
class Program
{
    static void Main()
    {
        ShipmentDetails shipment = new ShipmentDetails();

        Console.Write("Enter Shipment Code: ");
        shipment.ShipmentCode = Console.ReadLine();
        if (!shipment.ValidateShipmentCode())
        {
            Console.WriteLine("Invalid shipment code");
            return;
        }
        Console.Write("Enter Transport Mode (Sea/Air/Land): ");
        shipment.TransportMode = Console.ReadLine();
        Console.Write("Enter Weight: ");
        shipment.Weight = double.Parse(Console.ReadLine());
        Console.Write("Enter Storage Days: ");
        shipment.StorageDays = int.Parse(Console.ReadLine());
        double cost = shipment.CalculateTotalCost();
        Console.WriteLine($"The total shipping cost is {cost:F2}");
    }
}
