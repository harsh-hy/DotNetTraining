using System;
class BankAccount
{
    public static void Main()
    {
        // TODO:
        // 1. Throw exception if amount <= 0
        // 2. Throw exception if amount > balance
        // 3. Deduct amount if valid
        // 4. Use finally block to log transaction
        int balance = 10000;
        Console.WriteLine("Enter the withdrawl ammount");
        int amount = int.Parse(Console.ReadLine());
        try
        {
            if(amount<=0)
                throw new ArgumentException("Amount can not be less than or equal to 0");
            if(amount>balance)
                throw new ArgumentException("Amount cannot be Greater than Available Balance");
            balance-=amount;
            Console.WriteLine("Transaction Succesful\nAvailableBalance = "+balance);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error :"+ex);
        }
        finally
        {
            Console.WriteLine("Transaction attempt Logged");
        }
    }
}