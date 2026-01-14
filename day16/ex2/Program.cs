
using System;

class Program
{
    static void Main()
    {

        // Predicate<int> isEven = number => number%2 ==0;
        // bool check = isEven(10);
        // Console.WriteLine(check);

        Action<string> logger;

        if(DateTime.Now.Hour < 12)
        {
            logger= GoodMorning();
        }
        else
        {
            logger=GoodNight();
        }

        // logger = message =>
        // {
        //     Console.WriteLine($"{message.ToUpper()} at {DateTime.Now}");
        // };
        logger("Application Started");
    }
    private static Action<string> GoodMorning()
    {
        return message =>
        {
            Console.WriteLine($"{message} Good Morning");
        };
    }
    private static Action<string> GoodNight()
    {
        return message =>
        {
            Console.WriteLine($"{message} Good Night");
        };
    }
}

