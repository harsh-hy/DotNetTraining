using System;

class Controller
{
    static void Main()
    {
        // Call Service method
        try
        {
            Service.Process();
        }
        // Handle exception here
        catch(Exception ex)
        {
            Console.WriteLine("Controller Handeled Exception: "+ex.Message);
        }
    }
}

class Service
{
    public static void Process()
    {
        // Call Repository method
        try
        {
            Repository.GetData();
        }
        // Catch, log and rethrow exception
        catch(Exception ex)
        {
            Console.WriteLine("Service Handeled Exception: "+ex.Message);
            throw;
        }
    }
}

class Repository
{
    public static void GetData()
    {
        // Throw an exception here
        throw new Exception("Database Connection Failed!");
    }
}
