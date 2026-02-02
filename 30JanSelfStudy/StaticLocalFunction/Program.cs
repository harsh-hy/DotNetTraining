using System;
class Order
{
    private decimal amount;
    public void PlaceOrder(decimal value)
    {
        if(value>0)
            amount = value;
        decimal CalculateTax(decimal amt)
        {
            return (amt*0.18m);
        }
        decimal tax=CalculateTax(amount);
        decimal newAmt=amount+tax;
        static decimal ApplyDiscount(decimal cost)
        {
            return (cost*0.1m);
        }
        decimal disAmt=newAmt-ApplyDiscount(newAmt);
        Console.WriteLine("TAX: "+tax);
        Console.WriteLine("Amount after discount: "+disAmt);
    }
    public static void Main(String[] argg)
    {
        Console.Write("Enter the cost of goods :");
        decimal costOfGoods= decimal.Parse(Console.ReadLine());
        new Order().PlaceOrder(costOfGoods);
    }
}
