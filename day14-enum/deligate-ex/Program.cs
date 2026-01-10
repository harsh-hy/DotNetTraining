//callbacks using delegates
// Demonstrates how to use delegates as callbacks in C#
// 1) Define a delegate type
// 2) Accept a delegate as a parameter in a method
// 3) Invoke the delegate to perform a callback action
// This example simulates an order processing system where a notification is sent after placing an order.
// The notification method is passed as a delegate to the order processing method.

using System;

namespace CallbacksWithDelegates
{
    // 1) Create a delegate type (signature: void (string))
    public delegate void Notify(string message);

    class OrderService
    {
        // 2) Accept a delegate as parameter (callback)
        public void PlaceOrder(string orderId, Notify callback)
        {
            Console.WriteLine($"Order {orderId} placed.");

            // 3) Call the callback (when something important happens)
            callback?.Invoke($"Order {orderId} confirmation sent!");
        }
    }

    class Program
    {
        static void Main()
        {
            var service = new OrderService();

            // Pass a method as callback
            service.PlaceOrder("ORD-101", SendEmail);

            // Pass another method as callback
            service.PlaceOrder("ORD-102", SendSms);
        }

        static void SendEmail(string msg) => Console.WriteLine("EMAIL: " + msg);
        static void SendSms(string msg) => Console.WriteLine("SMS:   " + msg);
    }
}