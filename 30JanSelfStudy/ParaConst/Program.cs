using System;
class BankAccount
{
    private decimal balance;
    public BankAccount()
    {
        balance =0;
    }
    public BankAccount(decimal amount)
    {
        if(amount>0)
            balance=amount;
    }
    public void Deposit(decimal amount)
    {
        if(amount > 0)
            balance += amount;
    }
    public decimal GetBalance()
    {
        return balance;
    }
    public static void Main(string[] args)
    {
        BankAccount account = new BankAccount(1000); // 1000 is the balance held befor also for the example of para const
        account.Deposit(2000);
        Console.WriteLine("Balance : "+account.GetBalance());
    }
}