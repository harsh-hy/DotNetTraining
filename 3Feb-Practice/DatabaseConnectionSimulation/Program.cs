using System;

class DatabaseConnection
{
    static void Main()
    {
        bool connectionOpen = false;
        try
        {
            connectionOpen = true;
            Console.WriteLine("Database connection opened.");
            throw new Exception("Database operation failed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (connectionOpen)
            {
                connectionOpen = false;
                Console.WriteLine("Database connection closed.");
            }
        }
    }
}
