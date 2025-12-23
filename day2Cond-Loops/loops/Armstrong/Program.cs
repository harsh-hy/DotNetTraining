using System;

class Armstrong
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int temp = number;
        int sum = 0;

        while (temp > 0)
        {
            int digit = temp % 10;
            sum += digit * digit * digit;
            temp /= 10;
        }

        if (sum == number)
            Console.WriteLine($"{number} is an Armstrong Number");
        else
            Console.WriteLine($"{number} is not an Armstrong Number");
    }
}
