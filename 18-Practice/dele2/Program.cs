public delegate void Greet();
public delegate int Calculator(int x, int y);
class Program
{
    public static void SayHi()
    {
        Console.WriteLine("Hi Delegates ");
    }
    public static int Sum(int a, int b)
    {
        return a+b;
    }
    public static int Product(int num1, int num2)
    {
        return num1*num2;

    }
    public static void Main()
    {
        Greet gg = SayHi;
        gg();
        gg.Invoke();

        Calculator cal1 = Sum;
        Calculator cal2 = Product;

        Console.WriteLine(cal1(72,9));
        Console.WriteLine(cal2(9,9));
    }
}
