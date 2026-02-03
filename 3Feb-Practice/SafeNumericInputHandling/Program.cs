using System;
class InputHandler
{
    static void Main()
    {
        // 1. Read input from user
        while(true)
        {
            try
            {
                Console.Write("Enter the no: ");
                int n=int.Parse(Console.ReadLine());
                Console.WriteLine("Valid no Entered: "+n);
                break;
            }
            catch(FormatException)
            {
                Console.WriteLine("Error!! Invlaid no entred!");
            }
            catch(OverflowException)
            {
                Console.WriteLine("Error!! Number Entered is too Large!");
            }
        }
        // 2. Handle invalid numeric input
        // 3. Keep asking until valid number is entered
    }
}
