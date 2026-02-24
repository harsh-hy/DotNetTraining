public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message):base(message)
    {

    }
}
class Program
{
    public static void Main()
    {
        int senderBalance = int.Parse(Console.ReadLine());
        int transferAmount = int.Parse(Console.ReadLine());
        try
        {
            if(transferAmount <= 0)
                throw new ArgumentException("trasfer amount connot be less than or equal to zero");
            if(transferAmount > senderBalance)
                throw new InsufficientFundsException("Insufficient Funds");
            if(transferAmount > 50000)
                throw new InvalidOperationException("Invalid Operation");
            senderBalance -= transferAmount;
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction Attempted");
        }
    }
}