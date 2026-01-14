using System;
using System.Linq;

public class LinqExample
{
    public LinqExample()
    {
        string[] names = { "Harsh", "Yash", "Naman", "Aman" , "tenet"};
        Console.WriteLine("\nPalindrome Check");
        var palindromeNames = from nam in names
                              where IsPalindrome(nam)
                              select nam;

        foreach (var n in palindromeNames)
            Console.WriteLine($"{n} is a palindrome");
    }
    public static bool IsPalindrome(string palCheck)
    {
        string reversed = new string(palCheck.Reverse().ToArray());
        return palCheck.Equals(reversed, StringComparison.OrdinalIgnoreCase);
    }
    
}

public class Example
{
    public static void Main()
    {
        LinqExample obj = new LinqExample();
    }
}
