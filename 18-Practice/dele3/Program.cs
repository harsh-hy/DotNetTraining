public delegate void Logger();
public delegate void Operation(int a,int b);
class Program
{
    public static void WriteLog()
    {
        Console.WriteLine("Log Written");
    }
    public static void StartProcess(Logger Log)
    {
        Console.WriteLine("Process Started");
        Log();
    }

    public static void Divide(int a, int b)
    {
        Console.WriteLine(a/b);
    }
    public static void Modulus(int a, int b)
    {   
        Console.WriteLine(a%b);
    }
    public static void Calculate(Operation op)
    {
        op(20,4);
    }

    public static void Main()
    {
        StartProcess(WriteLog);

        Calculate(Divide);
        Calculate(Modulus);
    }
}