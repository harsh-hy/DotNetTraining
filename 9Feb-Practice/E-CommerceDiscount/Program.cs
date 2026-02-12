
using System;

namespace ConsoleApp1
{
    abstract class DiscountPolicy
    {
        public abstract double GetFinalAmount(double amount);
    }
    class FestivalDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if (amount >= 5000)
                return amount - (amount * 0.1);
            else
                return amount - (amount * 0.05);
        }
    }
    class MemberDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if (amount >= 2000)
                return amount - 300;
            else
                return amount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DiscountPolicy discountPolicy = new FestivalDiscount();
            Console.WriteLine(discountPolicy.GetFinalAmount(6000));
            discountPolicy = new MemberDiscount();
            Console.WriteLine(discountPolicy.GetFinalAmount(6000));
        }
    }
}