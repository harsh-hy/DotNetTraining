using System;
class Program
{
    public static void Main()
    {
        int a= 10;
        int b= 22;
        Swap<int>(ref a, ref b);
        Console.WriteLine($"a = {a} | b = {b}");

        string name1= "John";
        string name2= "Paul";
        Swap(ref name1, ref name2);
        Console.WriteLine($"name1 = {name1} | name2 = {name2}");

    }
    public static void Swap<T>(ref T left, ref T right)
    {
        T temp = left;
        left = right;
        right = temp;
    }
}