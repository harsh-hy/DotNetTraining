using System;
public class InvalidMarksException : Exception
{
    public InvalidMarksException(string message) : base(message)
    {

    }
}
public class Program
{
    public static void Main()
    {
        int marks = int.Parse(Console.ReadLine());
        try
        {
            if(marks >100 || marks <0)
            {
                throw new InvalidMarksException("Marks must be beteen 0 and 100");
            }
        }
        catch(InvalidMarksException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}