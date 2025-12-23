using System;

class ProfitLoss
{
    static void Main()
    {
        Console.Write("Enter Cost Price (CP): ");
        double cp = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Selling Price (SP): ");
        double sp = Convert.ToDouble(Console.ReadLine());

        if (sp > cp)
        {
            double profit = sp - cp;
            Console.WriteLine($"Profit = {profit}");
        }
        else if (cp > sp)
        {
            double loss = cp - sp;
            Console.WriteLine($"Loss = {loss}");
        }
        else
        {
            Console.WriteLine("No Profit No Loss");
        }
    }
}
