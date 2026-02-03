using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        string filePath = "data.txt";
        // 1. Read file content
        try{
            using(StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
        }
        // 2. Handle FileNotFoundException
        catch(FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
        // 3. Handle UnauthorizedAccessException
        catch(UnauthorizedAccessException)
        {
            Console.WriteLine("Unauthorized Access Exception");
        }
        // 4. Ensure resource is closed properly
        catch(Exception ex)
        {
            Console.WriteLine("Error : "+ex);
        }
    }
}