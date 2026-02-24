using System;
class Program
{
    public static void Main()
    {
        try
        {
            int a=int.Parse(Console.ReadLine());
            int b=int.Parse(Console.ReadLine());
        
            Console.WriteLine(a/b);
        }
        catch(DivideByZeroException)
        {
            Console.WriteLine("You Ccannot divide by zero!");
        }
        catch(FormatException)
        {
            Console.WriteLine("Only Numbers are Allowed not string!");
        }

    }
    
}