using System;
public class InvalidOrderException : Exception
{
    public InvalidOrderException(string message):base(message)
    {

    }
}
class OrderProcessor
{
    static void ProcessOrder(int n)
    {
        if(n>0)
            Console.WriteLine("Order processed successfully: " + n);
        else
            throw new InvalidOrderException("Invalid order ID: " + n);
    }
    static void Main()
    {
        int[] orders = { 101, -1, 103 };
        
        foreach(int id in orders)
        {
            Console.WriteLine("Order Processing ...");
            try
            {
                ProcessOrder(id);
            }
            catch(InvalidOrderException ex)
            {
                Console.WriteLine("Order Error: "+ex.Message);
            }
        }
        // TODO:
        // 1. Process each order
        // 2. Throw exception for invalid order ID
        // 3. Ensure one failure does not stop processing
    }
}
