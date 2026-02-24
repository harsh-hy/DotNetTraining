using System;
using System.Collections.Generic;
using System.linq;

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {

    }
}
public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message)
    {

    }
}
public class InvalidTransactionException: Exception
{
    public InvalidTransactionException(string message) : base(message)
    {

    }
}
public abstract class BankAccount
{
    public string AccountNumber{get;set;}
    public string CustomerName{get;set;}
    public decimal Balance{get;set;}

    public List<string> transHist = new List<string>();
    protected BankAccount(string acNo, string coName, decimal bal)
    {
        AccountNumber = acNo;
        CustomerName = coName;
        Balance = bal;
    }

    public virtual void Deposit(decimal amount)
    {
        if(amount <= 0)
            throw new InvalidTransactionException("Invalid Deposit Amount!");
        Balance += amount;
        transHist.Add($"Deposited {amount}");
    }
    public virtual void Withdraw(decimal amount)
    {
        if(amount <=0)
            throw new InvalidTransactionException("Invalid Withdraw amount!");
        if(amount > Balance)
            throw new InsufficientBalanceException("Insufficient Balance!");
        Balance -= amount;
        transHist.Add($"Withrawn {amount}");
    }
    public abstract decimal CalculateInterest();
    public override string ToString()
    {
        return $"{AccountNumber} | {CustomerName} | {Balance} | {GetType().Name}";
    }
}
public class SavingsAccount : BankAccount
{
    private decimal minimmBalance = 5000;
    public SavingsAccount(string acc , string name , decimal bal): base(acc , name , bal)
    {

    }
    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < minimumBalance)
            throw new MinimumBalanceException("Minimum balance violated");
        base.Withdraw(amount);
    }
    public override decimal CalculateInterest()
    {
        return balance*0.04m;
    }
}
public class CurrentAccount : BankAccount
{
    private decimal overdraftLimit = 20000;

    public CurrentAccount(string acc, string name, decimal bal): base(acc, name, bal) { }
    public override void Withdraw(decimal amount)
    {
        if (amount > Balance + overdraftLimit)
            throw new InsufficientBalanceException("Overdraft exceeded");
        Balance -= amount;
        TransactionHistory.Add($"Withdrawn {amount}");
    }
    public override decimal CalculateInterest()
    {
        return 0;
    }
}
public class LoanAccount : BankAccount
{
    public LoanAccount(string acc, string name, decimal bal) : base(acc, name, bal) { }

    public override void Deposit(decimal amount)
    {
        throw new InvalidTransactionException("Cannot deposit into loan account");
    }

    public override void Withdraw(decimal amount)
    {
        Balance += amount;
        TransactionHistory.Add($"Loan amount withdrawn {amount}");
    }

    public override decimal CalculateInterest()
    {
        return Balance * 0.10m;
    }
}
public class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();

    static BankAccount FindAccount(string acc)
    {
        return accounts.FirstOrDefault(a => a.AccountNumber == acc);
    }
    static void SeedData()
    {
        accounts.Add(new SavingsAccount("A1", "John", 80000));
        accounts.Add(new CurrentAccount("A2", "Paul", 40000));
        accounts.Add(new CurrentAccount("A3", "George", 100000));
        accounts.Add(new SavingsAccount("A4", "Ringo", 60000));
        accounts.Add(new LoanAccount("A5", "Noel", 34000));
        accounts.Add(new LoanAccount("A6", "Liam", 42000));
    }

    static void LinqQueries()
    {
        Console.WriteLine("\n--- Balance > 50000 ---");
        var high = accounts.Where(a => a.Balance > 50000);
        foreach (var a in high)
            Console.WriteLine(a);
        Console.WriteLine("\nTotal Bank Balance:");
        Console.WriteLine(accounts.Sum(a => a.Balance));
        Console.WriteLine("\nTop 3 Highest Balance:");
        var top3 = accounts.OrderByDescending(a => a.Balance).Take(3);
        foreach (var a in top3)
            Console.WriteLine(a);
        Console.WriteLine("\nGroup By Account Type:");
        var groups = accounts.GroupBy(a => a.GetType().Name);
        foreach (var g in groups)
        {
            Console.WriteLine(g.Key);
            foreach (var a in g)
                Console.WriteLine(" " + a);
        }

        Console.WriteLine("\nCustomers starting with R:");
        var rnames = accounts.Where(a => a.CustomerName.StartsWith("R"));
        foreach (var a in rnames)
            Console.WriteLine(a);
    }

    public static void Main()
    {
        SeedData();

        while (true)
        {
            Console.WriteLine("\n1.View Accounts\n2.Deposit\n3.Withdraw\n5.Calculate Interest\n6.Linq Reports\n7.Exit");
            int ch = int.Parse(Console.ReadLine());
            try
            {
                if (ch == 1)
                {
                    accounts.ForEach(a => Console.WriteLine(a));
                }
                else if (ch == 2)
                {
                    Console.Write("Acc: ");
                    var acc = FindAccount(Console.ReadLine());
                    Console.Write("Amount: ");
                    decimal amt = decimal.Parse(Console.ReadLine());
                    acc.Deposit(amt);
                }
                else if (ch == 3)
                {
                    Console.Write("Acc: ");
                    var acc = FindAccount(Console.ReadLine());
                    Console.Write("Amount: ");
                    decimal amt = decimal.Parse(Console.ReadLine());
                    acc.Withdraw(amt);
                }
                else if (ch == 5)
                {
                    foreach (var a in accounts)
                        Console.WriteLine($"{a.AccountNumber} Interest: {a.CalculateInterest()}");
                }
                else if (ch == 6)
                {
                    LinqQueries();
                }
                else if (ch == 7)
                {
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

