using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main()
    {
        Console.WriteLine("A");
        await Task.Delay(2756);
        await PrintAfterDelayAsync();
        Console.WriteLine("C");
    }

    static async Task PrintAfterDelayAsync()
    {
        Console.WriteLine("B1");
        await Task.Delay(2756);
        Console.WriteLine("B2");
        await Task.Delay(2756);
    }
}


//fetch the recrd from google 
