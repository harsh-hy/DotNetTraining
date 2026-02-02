using Application;
using Infrastructure;
using Domain;
using System;
class Program
{
    static void Main()
    {
        ILibraryRepository repo = new LibraryRepository();
        LibraryUtility library = new LibraryUtility(repo);
        while (true)
        {
            Console.WriteLine("\n1. Add Book");
            Console.WriteLine("2. Display Books Grouped by Genre");
            Console.WriteLine("3. Search Books by Author");
            Console.WriteLine("4. Show Statistics");
            Console.WriteLine("5. Exit");
            Console.Write("Choice: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Author: ");
                    string author = Console.ReadLine();
                    Console.Write("Genre: ");
                    string genre = Console.ReadLine();
                    Console.Write("Year: ");
                    int year = int.Parse(Console.ReadLine());
                    library.AddBook(title, author, genre, year);
                    Console.WriteLine("Book added!");
                    break;
                case "2":
                    var grouped = library.GroupBooksByGenre();
                    foreach (var g in grouped)
                    {
                        Console.WriteLine($"\nGenre: {g.Key}");
                        foreach (var b in g.Value)
                            Console.WriteLine($"{b.Id}. {b.Title} - {b.Author} ({b.PublicationYear})");
                    }
                    break;
                case "3":
                    Console.Write("Author Name: ");
                    var books = library.GetBooksByAuthor(Console.ReadLine());
                    foreach (var b in books)
                        Console.WriteLine($"{b.Title} ({b.Genre})");
                    break;
                case "4":
                    Console.WriteLine($"Total Books: {library.GetTotalBooksCount()}");
                    break;
                case "5":
                    return;
            }
        }
    }
}
