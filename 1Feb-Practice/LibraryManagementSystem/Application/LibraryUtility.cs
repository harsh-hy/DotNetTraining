using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application;

public class LibraryUtility
{
    private ILibraryRepository repository;
    private int idCounter = 1;

    public LibraryUtility(ILibraryRepository repository)
    {
        this.repository = repository;
    }

    public void AddBook(string title, string author, string genre, int year)
    {
        repository.Add(new Book
        {
            Id = idCounter++,
            Title = title,
            Author = author,
            Genre = genre,
            PublicationYear = year
        });
    }

    public SortedDictionary<string, List<Book>> GroupBooksByGenre()
    {
        return repository.GetAll()
            .GroupBy(b => b.Genre)
            .OrderBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.ToList())
            .ToSortedDictionary();
    }

    public List<Book> GetBooksByAuthor(string author)
    {
        return repository.GetAll()
            .Where(b => b.Author.Equals(author, System.StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public int GetTotalBooksCount()
    {
        return repository.GetAll().Count;
    }
}

static class Extensions
{
    public static SortedDictionary<TKey, TValue> ToSortedDictionary<TKey, TValue>(
        this Dictionary<TKey, TValue> dict)
    {
        return new SortedDictionary<TKey, TValue>(dict);
    }
}
