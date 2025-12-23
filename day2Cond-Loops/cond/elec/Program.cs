using System;

public class ElectricityBill
{
    static void Main()
    {
        Console.Write("Enter the meter value in units: ");
        double units = Convert.ToDouble(Console.ReadLine());

        double amount;

        if (units < 200)
        {
            amount = units * 1.20;
        }
        else if (units <= 400)
        {
            amount = units * 1.50;
            amount += amount * 0.15;
        }
        else if (units <= 600)
        {
            amount = units * 1.80;
            amount += amount * 0.15;
        }
        else
        {
            amount = units * 2.00;
            amount += amount * 0.15;
        }

        Console.WriteLine($"Electricity Bill Amount: ₹{amount:F2}");
    }
}
