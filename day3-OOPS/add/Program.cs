using System;

namespace Add
{
    public class Addition
    {
        public int FirstNumber { get; }
        public int SecondNumber { get; }
        public int Sum { get; }

        // Public parameterized constructor
        public Addition(int a, int b)
        {
            FirstNumber = a;
            SecondNumber = b;
            Sum = FirstNumber + SecondNumber;
        }
    }

    class Program
    {
        static void Main()
        {
            Addition add = new Addition(10, 20);
            Console.WriteLine($"Sum = {add.Sum}");
        }
    }
}
