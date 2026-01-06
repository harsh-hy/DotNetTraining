using System;
namespace Delegation
{
    public delegate int DelegatFuncion(int a, int b);
    public class ExampleOfDelegate
    {
        public int a;
        public int b;
        public void DelegateExi() // Example method to demonstrate delegate usage
        {
            // Instantiate delegates pointing to Add and Subtract methods
            DelegatFuncion delAdd = new DelegatFuncion(Add); 
            DelegatFuncion delSub = new DelegatFuncion(Subtract);
            Console.WriteLine("Addition: " + delAdd(10,5));
            Console.WriteLine("Subtraction: " + delSub(15,5));
        }
        private int Add(int a, int b) // Method to add two integers with an additional constant
        {
            return a + b + 10;
        }
        private int Subtract(int a, int b)// Method to subtract two integers with an additional constant
        {
            return a - b - 5;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ExampleOfDelegate example = new ExampleOfDelegate(); // Create an instance of ExampleOfDelegate
            example.DelegateExi();
        }
    }
}