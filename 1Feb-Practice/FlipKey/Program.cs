using System;              // Provides basic input-output functionality
using System.Linq;          // Required for Reverse() method

// Class name as given
class FlipKey
{
    // Method to clean the string, filter characters, reverse and format output
    public static string CleanseAndInvert(string input)
    {
        // STEP 1: Input validation
        // Check if string is null, empty, or has length less than 6
        // If any condition is true, return empty string as invalid input
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return "";
        }

        // STEP 2: Convert entire string to lowercase
        // This ensures uniform processing of characters
        input = input.ToLower();

        // STEP 3: Convert string to character array
        // Makes it easy to process each character individually
        char[] characters = input.ToCharArray();

        // String to store filtered characters
        string filteredString = "";

        // STEP 4: Iterate through each character
        foreach (char ch in characters)
        {
            // STEP 4.1: Check if character is an alphabet
            // If any non-letter character is found, return empty string
            if (!char.IsLetter(ch))
                return "";

            // STEP 4.2: Convert character to ASCII value
            int asciiValue = ch;

            // STEP 4.3: Check if ASCII value is odd
            // If odd, append the character to filteredString
            if (asciiValue % 2 != 0)
                filteredString += ch;
        }

        // STEP 5: Reverse the filtered string
        // Convert to char array → reverse → convert back to string
        filteredString = new string(filteredString.Reverse().ToArray());

        // STEP 6: Convert reversed string into character array
        char[] result = filteredString.ToCharArray();

        // STEP 7: Capitalize characters at even indexes
        for (int i = 0; i < result.Length; i++)
        {
            // If index is even, convert character to uppercase
            if (i % 2 == 0)
                result[i] = char.ToUpper(result[i]);
        }

        // STEP 8: Convert final character array to string and return
        return new string(result);
    }

    // Main method - program execution starts here
    public static void Main()
    {
        // Prompt user for input
        Console.Write("Enter the string: ");

        // Read user input
        string input = Console.ReadLine();

        // Call CleanseAndInvert method
        string output = CleanseAndInvert(input);

        // Display the final result
        Console.WriteLine("Ans: " + output);
    }
}
