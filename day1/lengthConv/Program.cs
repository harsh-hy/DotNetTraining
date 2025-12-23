using System;

class Program
{
    static void Main()
    {
        const double CmPerFoot = 30.48;

        Console.Write("Enter feet: ");
        string? input = Console.ReadLine();

        if (!double.TryParse(input, out double feet))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        if (feet < 0)
        {
            Console.WriteLine("Feet cannot be negative.");
            return;
        }

        double cm = feet * CmPerFoot;
        Console.WriteLine($"{feet} feet = {cm:F2} cm");
    }
}
