using System;

class Program
{
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static void Main()
    {
        int x = 10;
        int y = 20;
        Console.WriteLine("Before Swap:");
        Console.WriteLine($"x = {x}, y = {y}");
        Swap(ref x, ref y);
        Console.WriteLine("After Swap:");
        Console.WriteLine($"x = {x}, y = {y}");
    }
}