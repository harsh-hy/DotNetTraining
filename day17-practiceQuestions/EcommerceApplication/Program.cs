using System;
using System.Collections.Generic;
using System.Linq;
namespace Ecom
{
    class EcommerceShop
    {
        public string UserName{get;set;}
        public double WalletBalance{get;set;}
        public double TotalPurchaseAmount{get;set;}
    }
    public class InsufficientBalanceException:Exception
    {
        public InsufficientBalanceException(string? message):base(message) { }
    }
    class Program
    {
        public static EcommerceShop MakePayment(string name, double balance,double amount)
        {
            if(balance<amount)
            {
                throw new InsufficientBalanceException("Insufficient balance in the account");
            }
            EcommerceShop ec = new EcommerceShop();
            ec.UserName = name;
            ec.WalletBalance = balance;
            ec.TotalPurchaseAmount=amount;
            return ec;
        }
        public static void Main()
        {
            Console.WriteLine("Enter the User Name");
            string? name=Console.ReadLine();
            Console.WriteLine("Enter the User Balance");
            double balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Amount");
            double amount = Convert.ToDouble(Console.ReadLine());

            try{
            EcommerceShop result=MakePayment(name,balance,amount);
            if(result!=null)
            {
                Console.WriteLine("Payment Successful");
                Console.WriteLine($"User Name : {name}\nWallet Balance : {balance}\nTotal Purchase Amount : {amount}\nRemaining Balance :{balance-amount}");
            }
            }
            catch(InsufficientBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
