using System.Threading.Tasks;

public class GreetingService
{
    public static async Task<string> GetGreetingAsync(string name)
    {
        await Task.Delay(9000); // pretend network delay
        return $"Hello, {name}!";
    }
    public static async Task Main()
    {
        string greet = await GetGreetingAsync("Harsh");
        Console.WriteLine(greet);
    }
}
