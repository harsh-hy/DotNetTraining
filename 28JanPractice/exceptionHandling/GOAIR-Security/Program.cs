using System;
using System.Text.RegularExpressions;
namespace GOAIR
{
    class InvalidEntryException:Exception
    {
        public InvalidEntryException (string message):base (message)
        {

        }
    }
    class EntryUtility
    {
        public bool validateEmployeeId(string str)
        {
            if(str.Length!=10)
                throw new InvalidEntryException("Invalid entry details");
            if (!Regex.IsMatch(str, @"^GOAIR\/\d{4}$"))
                throw new InvalidEntryException("Invalid entry details");
            return true;
        }
        public bool validateDuration(int duration)
        {
            if(duration<1 || duration>5)
                throw new InvalidEntryException("Invalid entry details");
            return true;
        }
    }
    class UserInterface
    {
        public static void Main(string[] args)
        {
            EntryUtility utility = new EntryUtility();
            Console.WriteLine("Enter the number of entries");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter entry {i} details");
                string input = Console.ReadLine();
                try
                {
                    string[] parts = input.Split(':');
                    string employeeId = parts[0];
                    int duration = Convert.ToInt32(parts[2]);
                    utility.validateEmployeeId(employeeId);
                    utility.validateDuration(duration);
                    Console.WriteLine("Valid entry details");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid entry details");
                }
            }
        }
    }
}

