using System;

class VowelConsonant
{
    static void Main()
    {
        Console.Write("Enter a character: ");
        char ch = Convert.ToChar(Console.ReadLine().ToLower());

        if (ch >= 'a' && ch <= 'z')
        {
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                Console.WriteLine($"{ch} is a Vowel");
            else
                Console.WriteLine($"{ch} is a Consonant");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter an alphabet.");
        }
    }
}
