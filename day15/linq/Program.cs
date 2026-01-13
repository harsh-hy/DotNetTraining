using System;
using System.Linq;

public class LinqExample
{
    public LinqExample()
    {
        string[] names = { "Harsh", "Yash", "Naman", "Aman" , "tenet"};

        // Find "Yash"
        var findName = from nam in names
                       where nam == "Yash"
                       select nam;

        // Uppercase names
        var upperName = from nam in names
                        select nam.ToUpper();

        // Order names ascending
        var orderName = from nam in names
                        orderby nam ascending
                        select nam;

        // Output
        if (findName.Any())
        {
            Console.WriteLine("Found name Yash");
        }
        else
        {
            Console.WriteLine("Yash not found");
        }

        Console.WriteLine("\nUppercase Names:");
        foreach (var n in upperName)
            Console.WriteLine(n);

        Console.WriteLine("\nOrdered Names:");
        foreach (var n in orderName)
            Console.WriteLine(n);
        
    }

}

public class Example
{
    public static void Main()
    {
        LinqExample obj = new LinqExample();
    }
}
