using System;

namespace Github
{
    public class Calculator
    {
        static void Main()
        {
            Console.Write("Enter first number: ");
            decimal num1 = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter second number: ");
            decimal num2 = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter operation (+, -, *, /): ");
            char operation = Convert.ToChar(Console.ReadLine());

            string result = Calculate(num1, num2, operation);
            Console.WriteLine(result);
        }

        public static string Calculate(decimal num1, decimal num2, char operation)
        {
            switch (operation)
            {
                case '+':
                    return $"Result: {num1 + num2}";

                case '-':
                    return $"Result: {num1 - num2}";

                case '*':
                    return $"Result: {num1 * num2}";

                case '/':
                    if (num2 == 0)
                        return "Error: Division by zero is not allowed.";
                    return $"Result: {num1 / num2}";

                default:
                    return "Invalid operation. Use +, -, *, or /.";
            }
        }
    }
}
