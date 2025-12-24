using System;

namespace OopsSession
{
    public interface IPrint
    {
        void Print();
    }
    public class Document : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Printing document...");
        }
    }
    public class Photo : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Printing photo...");
        }
    }

    class Program
    {
        static void Main()
        {
            IPrint doc = new Document();
            IPrint photo = new Photo();

            doc.Print();
            photo.Print();
        }
    }
}
