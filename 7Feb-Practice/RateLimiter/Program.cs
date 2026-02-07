using System;
using System.Collections.Generic;
public class SlidingWindowRateLimiter
{
    private Dictionary<string, Queue<DateTime>> requests = new Dictionary<string, Queue<DateTime>>();
    private object Lock = new object();
    private const int MAX_REQUESTS = 5;
    private static TimeSpan WINDOW = TimeSpan.FromSeconds(10);
    public bool AllowRequest(string clientId, DateTime now)
    {
        lock (Lock)
        {
            if (!requests.ContainsKey(clientId))
            {
                requests[clientId] = new Queue<DateTime>();
            }
            Queue<DateTime> timestamps = requests[clientId];
            while (timestamps.Count > 0 && now - timestamps.Peek() > WINDOW)
            {
                timestamps.Dequeue();
            }
            if (timestamps.Count >= MAX_REQUESTS)
            {
                return false;
            }
            timestamps.Enqueue(now);
            return true;
        }
    }
}
class Program
{
    public static void Main()
    {
        SlidingWindowRateLimiter limiter = new SlidingWindowRateLimiter();
        string clientId = "client-1";
        DateTime start = DateTime.Now;
        for (int i = 1; i <= 6; i++)
        {
            bool allowed = limiter.AllowRequest(clientId, DateTime.Now);
            Console.WriteLine("Request " + i + " allowed: " + allowed);
            Thread.Sleep(1000);
        }
        Thread.Sleep(5000);
        Console.WriteLine("After waiting...");
        bool result = limiter.AllowRequest(clientId, DateTime.Now);
        Console.WriteLine("Request after window allowed: " + result);
    }
}
