using System;              
using System.Linq;         
class FlipKey
{
    public static string CleanseAndInvert(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return "";
        }
        input = input.ToLower();
        char[] characters = input.ToCharArray();
        string filteredString = "";
        foreach (char ch in characters)
        {
            if (!char.IsLetter(ch))
                return "";
            int asciiValue = ch;
            if (asciiValue % 2 != 0)
                filteredString += ch;
        }
        filteredString = new string(filteredString.Reverse().ToArray());
        char[] result = filteredString.ToCharArray();
        for (int i = 0; i < result.Length; i++)
        {
            if (i % 2 == 0)
                result[i] = char.ToUpper(result[i]);
        }
        return new string(result);
    }
    public static void Main()
    {
        Console.Write("Enter the string: ");
        string input = Console.ReadLine();
        string output = CleanseAndInvert(input);
        Console.WriteLine("Ans: " + output);
    }
}
