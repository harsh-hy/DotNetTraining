using System;
using System.Runtime.CompilerServices;
namespace GenericDelegateValidator
{
    public delegate bool Validator<T>(T data);
    
    class Program
    {
        public static bool IsPositive( int number)
        {
            return number>0;
        }
        public static bool IsAdult(int age)
        {
            return age>17;
        }
        public static bool IsName(string? name)
        {
            return !string.IsNullOrEmpty(name) && name.Length>=3;
        }
        public static void Main(string[] args)
        {
            Validator<int> numberValidator = IsPositive;
            Console.WriteLine("Is 10 positive? Ans: " + numberValidator(10));
            Console.WriteLine("Is -5 positive? Ans: " + numberValidator(-5));
            Validator<int> ageValidator = IsAdult;
            Console.WriteLine("\nIs 18 adult? Ans: " + ageValidator(18));
            Console.WriteLine("Is 15 adult? Ans: " + ageValidator(15));
            Validator<string> nameValidator = IsName;
            Console.WriteLine("\nIs 'John' a valid name? Ans: " + nameValidator("Harsh"));
            Console.WriteLine("Is 'YO' a valid name? Ans: " + nameValidator("YO"));
        }
    }
}