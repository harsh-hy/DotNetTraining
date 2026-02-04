using System;

class FileUpload
{
    static void Main()
    {
        string fileName = "report.exe";
        int fileSize = 8; // MB

        // TODO:
        try
        {
            if (!fileName.EndsWith(".exe"))
            {
                throw new ArgumentException("Invalid file type.");
            }
            if(fileSize > 5)
            {
                throw new InvalidOperationException("Invalid file size");
            }
            Console.WriteLine("File uploaded successfully.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Extension Error: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Size Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Upload Error: " + ex.Message);
        }
    }
}
