using System;

namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Divider cannot be zero");
            if (b < 0)
                throw new ArgumentException("Divider cannot be negative");
            return a / b;
        }
        public List<int> GetNumbers()
        {
            return new List<int> { 1, 2, 3 };
        }
    }
}
