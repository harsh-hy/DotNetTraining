using System;
public class LoginFailedException : Exception
{
    public LoginFailedException (string message):base(message)
    {

    }
}
class LoginSystem
{
    static void Main()
    {
        int attempts = 0;
        string correctPassword="12344321";
        try
        {
            while(attempts<3)
            {
                Console.Write("Enter Password: ");
                string pass=Console.ReadLine();
                attempts++;
                if(correctPassword==pass)
                {
                    Console.WriteLine("Login Successful!");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Password, Try Again!");
                }
            }
            throw new LoginFailedException("Maximum login attempts exceeded.!!");
        }
        catch(LoginFailedException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
