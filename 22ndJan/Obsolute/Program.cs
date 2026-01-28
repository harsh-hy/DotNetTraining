using System;
namespace attri
{
    public class Calculator
    {
        [Obsolete("USe the Add(int , int) method instead.")]
        public int OldAdd(int a, int b)
        {
            return a + b;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    public class ExampleOfAttribute
    {
        public static void Main()
        {
            Calculator calc = new Calculator();
            // This will show a compiler warning because OldAdd is marked Obsolete
            int result1 = calc.OldAdd(10, 20);
            Console.WriteLine("OldAdd Result: " + result1);
            // Recommended method
            int result2 = calc.Add(10, 20);
            Console.WriteLine("Add Result: " + result2);
        }
    }
}