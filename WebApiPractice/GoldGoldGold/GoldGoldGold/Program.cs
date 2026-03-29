using System;

class Program
{
    static void Main()
    {
        var goldSaleService = new GoldSaleService();
        var valuationService = new ValuationService();
        var pricingService = new PricingService();
        var paymentService = new PaymentService();

        goldSaleService.GoldSalePlaced += valuationService.EvaluateWeight;

        valuationService.WeightEvaluated += pricingService.CalculatePrice;

        pricingService.PriceCalculated += paymentService.ProcessPayment;

        goldSaleService.PlaceGoldSale("GOLD123");

        Console.ReadLine();
    }
}

public class GoldSaleService
{
    public event Action<string> GoldSalePlaced;

    public void PlaceGoldSale(string saleId)
    {
        Console.WriteLine($"Gold sale {saleId} initiated");

        GoldSalePlaced?.Invoke(saleId);
    }
}

public class ValuationService
{
    public event Action<string, double> WeightEvaluated;

    public void EvaluateWeight(string saleId)
    {
        double weight = 30.5; // grams

        Console.WriteLine($"Gold weight evaluated: {weight}g for {saleId}");

        WeightEvaluated?.Invoke(saleId, weight);
    }
}

public class PricingService
{
    public event Action<string, double> PriceCalculated;

    public void CalculatePrice(string saleId, double weight)
    {
        double pricePerGram = 6000;
        double totalPrice = weight * pricePerGram;

        Console.WriteLine($"Price calculated: Rs {totalPrice} for {saleId}");

        PriceCalculated?.Invoke(saleId, totalPrice);
    }
}

public class PaymentService
{
    public void ProcessPayment(string saleId, double amount)
    {
        Console.WriteLine($"Payment of Rs {amount} completed for {saleId}");
    }
}