using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Started!");
        await SaveAsync();                // Task (no return)
        Console.WriteLine("calculating 4+5 ......");
        int total = await GetTotalAsync(4,5); // Task<int> (returns value)
        Console.WriteLine(total);
    }

    static async Task SaveAsync()
    {
        await Task.Delay(5000); // pretend we saved to DB
        Console.WriteLine("Saved!");
    }

    static async Task<int> GetTotalAsync(int a,int b)
    {
        await Task.Delay(5000); // pretend we calculated
        return a+b;
    }
}