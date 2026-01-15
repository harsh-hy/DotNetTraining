using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace abcd
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Main started");

            await CallMethod();

            Console.WriteLine("Main ended");
        }

        public static async Task AsyncMethod()
        {
            Console.WriteLine("AsyncMethod started");
            await Task.Delay(2000);
            Console.WriteLine("AsyncMethod ended");
        }

        public static async Task<string> FetchDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string data = await response.Content.ReadAsStringAsync();
                return data;
            }
        }

        public static async Task CallMethod()
        {
            string result = await FetchDataAsync("https://jsonplaceholder.typicode.com/todos/1");
            Console.WriteLine("Fetched Data:");
            Console.WriteLine(result);

            await AsyncMethod();
        }
    }
}
