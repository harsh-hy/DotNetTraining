using Domain;
using Application;
using System.Collections.Generic;

namespace Infrastructure;

public class LibraryRepository : ILibraryRepository
{
    private readonly List<Book> books = new();

    public void Add(Book book)
    {
        books.Add(book);
    }

    public List<Book> GetAll()
    {
        return books;
    }
}
