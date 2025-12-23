using System;

namespace MyConsoleApp.Account
{
    // Base class
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }

        public virtual string GetAccountDetails()
        {
            return $"Account ID: {AccountId}\nAccount Name: {AccountName}";
        }
    }

    // Derived class - SalesAccount
    public class SalesAccount : Account
    {
        public string SalesInfo { get; set; }

        public override string GetAccountDetails()
        {
            return base.GetAccountDetails() +
                   "\nAccount Type: Sales" +
                   "\nSales Info: " + SalesInfo;
        }
    }

    // Derived class - PurchaseAccount
    public class PurchaseAccount : Account
    {
        public string PurchaseInfo { get; set; }

        public override string GetAccountDetails()
        {
            return base.GetAccountDetails() +
                   "\nAccount Type: Purchase" +
                   "\nPurchase Info: " + PurchaseInfo;
        }
    }

    // Entry point
    class Program
    {
        static void Main()
        {
            SalesAccount sales = new SalesAccount
            {
                AccountId = 101,
                AccountName = "ABC Traders",
                SalesInfo = "Handles retail sales"
            };

            PurchaseAccount purchase = new PurchaseAccount
            {
                AccountId = 202,
                AccountName = "XYZ Suppliers",
                PurchaseInfo = "Handles raw material purchase"
            };

            Console.WriteLine("---- Sales Account ----");
            Console.WriteLine(sales.GetAccountDetails());

            Console.WriteLine("\n---- Purchase Account ----");
            Console.WriteLine(purchase.GetAccountDetails());
        }
    }
}
