using System;
namespace UserAuth
{
    class User
    {
        public string? Name{get;set;}
        public string? PhoneNumber{get;set;}
    }
    public class InvalidPhoneNumberException:Exception
    {
        public InvalidPhoneNumberException(string? message):base(message){ }
    }
    class Program
    {
        public static User ValidatePhoneNumber(string name, string phoneNumber)
        {
            if(phoneNumber.Length!=10)
            {
                throw new InvalidPhoneNumberException("Invalid Phone Number");
            }
            User u = new User();
            u.Name = name;
            u.PhoneNumber = phoneNumber;
            return u;
        }
        public static void Main(string[] args)
        {
            User user = new User();
            Console.WriteLine("Enter the User Name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter the Phone Number");
            user.PhoneNumber = Console.ReadLine();
            try
            {
                ValidatePhoneNumber(user.Name,user.PhoneNumber);
                Console.WriteLine("Valid Phone Number :)");
            }
            catch(InvalidPhoneNumberException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}