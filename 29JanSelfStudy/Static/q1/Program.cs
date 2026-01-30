using System;
class MathUtils
{
    public static int Add(int a, int b)
    {
        return a+b;
    }
    public static int Add(int a, int b, int c)
    {
        return a+b+c;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("sum of 3 and 4 = "+Add(3,4));
        Console.WriteLine("sum of 3, 4 and 5 = "+Add(3,4,5));
    }
}