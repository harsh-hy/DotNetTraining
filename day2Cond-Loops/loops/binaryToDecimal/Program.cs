using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Enter a binary number: ");
        string binary = Console.ReadLine();

        int decimalValue = 0;
        int power = 0;

        for (int i = binary.Length - 1; i >= 0; i--)
        {
            if (binary[i] == '1')
                decimalValue += (int)Math.Pow(2, power);
            else if (binary[i] != '0')
            {
                Console.WriteLine("Invalid binary number");
                return;
            }
            power++;
        }

        Console.WriteLine($"Decimal value = {decimalValue}");
    }
}
