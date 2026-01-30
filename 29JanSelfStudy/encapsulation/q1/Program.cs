using System;
class BankAccount
{
    private double balance;
    public void Deposit(double amount)
    {
        if(amount>0)
            balance+=amount;
    }
    public void Withdraw(double amount)
    {
        if(amount > 0 && amount <= balance)
            balance -= amount;
    }
    public double GetBalance(){
        return balance;
    }
    public static void Main(string[] args)
    {
        BankAccount bk= new BankAccount();
        double amt=double.Parse(Console.ReadLine());
        bk.Deposit(amt);
        double withdrawAmt=double.Parse(Console.ReadLine());
        bk.Withdraw(withdrawAmt);
        Console.WriteLine("BALANCE = "+bk.GetBalance());

    }
}