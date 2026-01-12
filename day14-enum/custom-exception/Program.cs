using System;
namespace CustomExceptionExample
{
    // Define a custom exception class
    public class AppCustomException : Exception
    {
        public override Exception GetBaseException()
        {
            return base.GetBaseException();
        }
        public override string? Message => HandleBase(base.Message);
        private string HandleBase(string? sysMessage)
        {
            Console.WriteLine(sysMessage);
            return "Custom Exception Occurred please contact support team.";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Simulate an error condition
                int result = 10 / int.Parse("0");
            }
            catch (AppCustomException ex)
            {
                // Handle the custom exception
                Console.WriteLine(ex.Message);
            }
        }
    }
}