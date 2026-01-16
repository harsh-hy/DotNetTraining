using System;
namespace UserAuth
{
    class User
    {
        public string? Name{get;set;}
        public string? Password{get;set;}
        public string? ConfirmedPassword{get;set;}
    }
    public class PasswordMismatchException:Exception
    {
        public PasswordMismatchException(string? message):base(message){ }
    }
    class Program
    {
        public static User ValidatePassword(string name, string password, string confirmedPassword)
        {
            if(password!=confirmedPassword)
            {
                throw new PasswordMismatchException("Password and Confirm Password does not match");
            }
            User u = new User();
            u.Name = name;
            u.Password = password;
            u.ConfirmedPassword = confirmedPassword;
            return u;
        }
        public static void Main(string[] args)
        {
            User user = new User();
            Console.WriteLine("Enter the User Name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Enter the Password");
            user.Password = Console.ReadLine();
            Console.WriteLine("Enter the Confirm Password");
            user.ConfirmedPassword = Console.ReadLine();
            try
            {
                ValidatePassword(user.Name,user.Password,user.ConfirmedPassword);
                Console.WriteLine("Password is Valid !! :)");
            }
            catch(PasswordMismatchException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}