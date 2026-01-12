using System;
namespace Delegation
{
    public delegate double DisFnc(double discount);
    public class CalculateDiscount
    {
        public void DisDelegate(double amount) 
        {
            DisFnc dis10 = new DisFnc(Dis10); 
            DisFnc dis20 = new DisFnc(Dis20);
            Console.WriteLine("after 10% discount: " + dis10(amount));
            Console.WriteLine("after 20% discount: " + dis20(amount));
        }
        private double Dis10(double amount) 
        {
            return (amount - (amount * 0.1));
        }
        private double Dis20(double amount)
        {
            return (amount - (amount * 0.2));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the amount:");
            double amount = Convert.ToDouble(Console.ReadLine());
            CalculateDiscount dis = new CalculateDiscount();
            dis.DisDelegate(amount);
        }
    }
}