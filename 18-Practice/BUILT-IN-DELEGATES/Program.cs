class Program
{
    public static void Main()
    {
        Action<string> msg = s => Console.WriteLine($"Hello {s}");
        msg("Delegates");

        Func<int,int,double> power = (a,b) => Math.Pow(a,b);
        Console.WriteLine(power(2,3));

        Predicate<int> isPositive = s => s>0;
        Console.WriteLine(isPositive(-5));
    }
}