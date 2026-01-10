using System;
using System.Dynamic;
using System.Xml.Serialization;
namespace dele
{
    public delegate string printMessage(string? message);
    public class printCompany
    {
        public printMessage? CustomerChoicePrintMessage { get; set; }
        public void print(string? message)
        {
            string? messageToPrint = CustomerChoicePrintMessage?.Invoke(message);
            Console.WriteLine(messageToPrint);
        }
    }

    static class Program
    {
        public static string HappyDiwali(string? name)
        {
            return $"Happy Diwali {name}";
        }
        public static string HappyNewYear(string? name)
        {
            return $"Happy New Year {name}";
        }
        static void Main()
        {
            printCompany company = new printCompany();
            company.CustomerChoicePrintMessage=new printMessage(HappyNewYear);
            company.print("Harsh");
            company.CustomerChoicePrintMessage=new printMessage(HappyDiwali);
            company.print("Harsh");
        }
    }
}