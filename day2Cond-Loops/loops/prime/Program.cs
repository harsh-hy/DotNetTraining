using System;

class Prime
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number <= 1)
        {
            Console.WriteLine($"{number} is not a Prime Number");
            return;
        }

        bool isPrime = true;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime)
            Console.WriteLine($"{number} is a Prime Number");
        else
            Console.WriteLine($"{number} is not a Prime Number");
    }
}
