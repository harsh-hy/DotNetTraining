using System;
class Account
{
    private decimal balance;
    public void Deposit(decimal amount)
    {
        if(amount>0)
            balance +=amount;
    }
    public void ApplyBonus(ref decimal bonus)
    {
        balance=balance+(bonus*0.1m)+bonus;
    }
    public void GetBalance(out decimal currentBalance)
    {
        currentBalance=balance;
    }
    public static void Main(string[] args)
    {
        Account ac = new Account();
        ac.Deposit(20000.91m);
        decimal bonus = 1500;
        ac.ApplyBonus(ref bonus);
        decimal bal;
        ac.GetBalance(out bal);
        Console.WriteLine("balance = "+  bal);
    }
}