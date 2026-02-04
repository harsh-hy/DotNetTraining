using System;

class ExceptionRethrow
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception)
        {
            Console.WriteLine("An error occred while handeling the data");
        }
    }

    static void ProcessData()
    {
        try
        {
            int.Parse("ABC");
        }
        catch (Exception)
        {
            Console.WriteLine("Logging error in ProcessData.");
            throw;
        }
    }
}
