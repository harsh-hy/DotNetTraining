using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient _http = new HttpClient();

    static async Task Main(string[] args)
    {
        await FetchJsonAsync();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private static async Task FetchJsonAsync()
    {
        Console.WriteLine("Status: Fetching...");
        Console.WriteLine("---- " + DateTime.Now.ToString("HH:mm:ss.fff") + " ----");

        try
        {
            string url = "https://google.com";
            string json = await _http.GetStringAsync(url);

            Console.WriteLine(json);
            Console.WriteLine("Status: Success");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Console.WriteLine("Status: Failed");
        }
    }
}
