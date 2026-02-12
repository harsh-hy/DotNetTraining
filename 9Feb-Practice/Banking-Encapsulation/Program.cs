public class BankAccount 
{
    private double balance;
    public void Deposit(double amount)
    {
        if(amount>0){
            balance += amount;
            Console.WriteLine($"Deposited: {amount}. New balance: {balance}");
            return;
        }
        Console.WriteLine($"Error!!");
    }
    public void Withdraw(double amount)
    {
        if(amount>0 && amount<=balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}. Available balance: {balance}");
            return;
        }
        Console.WriteLine("Error!");
        
    }
    public static void Main()
    {
        BankAccount b1= new BankAccount();
        b1.Deposit(900000);
        b1.Withdraw(20000);
        b1.Deposit(5000);
        b1.Withdraw(100000);
        b1.Withdraw(450000);
    }
}