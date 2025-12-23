class Program
{
    static void Main()
    {
        Console.Write("Enter radius: ");
        string? input = Console.ReadLine();

        if (!double.TryParse(input, out double radius))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        if (radius < 0)
        {
            Console.WriteLine("Radius cannot be negative.");
            return;
        }

        double area = Math.PI * radius * radius;
        Console.WriteLine($"Area of circle = {area:F2}");
    }
}
