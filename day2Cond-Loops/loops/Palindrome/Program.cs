using System;

class Palindrome
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int original = number;
        int reverse = 0;

        while (number > 0)
        {
            int digit = number % 10;
            reverse = reverse * 10 + digit;
            number /= 10;
        }

        if (original == reverse)
            Console.WriteLine($"{original} is a Palindrome Number");
        else
            Console.WriteLine($"{original} is not a Palindrome Number");
    }
}
