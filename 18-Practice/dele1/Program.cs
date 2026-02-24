using System;
public delegate string Show(string msg);
public delegate int MathOp(int a, int b);
class Program
{
    public static string Message(string str)
    {
        return($"Hello {str}");
    }
    public static int Multiply(int a, int b)
    {
        return a*b;
    }
    public static int Subtract(int a, int b)
    {
        return a-b;
    }
    public static void Main()
    {
        Show s = Message;
        Console.WriteLine(s("Harsh"));

        MathOp mul=Multiply;
        Console.WriteLine(mul(9,9));

        MathOp sub=Subtract;
        Console.WriteLine(sub(90,9));
    }
}