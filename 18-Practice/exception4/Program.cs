class Program
{
    public static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        try
        {
            if(x < 0)
                throw new ArgumentException();
        }
        catch(ArgumentException) when (x < -100){
            Console.WriteLine("The no is negative by a long margin");
        }
        catch(ArgumentException)
        {
            Console.WriteLine("The number is negative");
        }
    }
}