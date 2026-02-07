using System;
using System.Threading;
class Account
{
    public int Id;
    public decimal Balance;
    public readonly object LockObj = new object();
    public Account(int id, decimal balance)
    {
        Id = id;
        Balance = balance;
    }
}
class Bank
{
    public static void SafeTransfer(Account a, Account b, decimal amount)
    {
        Account first = a.Id < b.Id ? a : b;
        Account second = a.Id < b.Id ? b : a;
        lock (first.LockObj)
        {
            lock (second.LockObj)
            {
                if (a.Balance < amount)
                    throw new InvalidOperationException("Insufficient balance");
                a.Balance -= amount;
                b.Balance += amount;
            }
        }
    }
    public static void Main()
    {
        Account acc1 = new Account(1, 1000);
        Account acc2 = new Account(2, 500);
        Thread t1 = new Thread(() => SafeTransfer(acc1, acc2, 200));
        Thread t2 = new Thread(() => SafeTransfer(acc2, acc1, 100));
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine(acc1.Balance);
        Console.WriteLine(acc2.Balance);
    }
}