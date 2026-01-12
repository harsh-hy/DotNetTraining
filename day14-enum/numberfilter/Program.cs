namespace numFilter
{
    public delegate bool NumberFilter(int num);
    public class Program
    {

        public static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
        public static bool IsOdd(int num)
        {
            return num % 2 != 0;
        }
        public static void PrintNumbers(int[] numbers, NumberFilter filter)
        {
            Console.WriteLine("Filtered Numbers:");
            foreach (var number in numbers)
            {
                if (filter(number))
                {
                    Console.WriteLine(number);
                }
            }
        }
        public static void Main(string[] args)
        {
            int[] nmbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Even Numbers:");
            NumberFilter filter = IsEven;
            PrintNumbers(nmbers, IsEven);
            Console.WriteLine("Odd Numbers:");
            filter = IsOdd;
            PrintNumbers(nmbers, IsOdd);
        }
    }
}