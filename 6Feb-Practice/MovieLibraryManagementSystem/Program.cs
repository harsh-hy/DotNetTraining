using System;
using System.Collections.Generic;
using System.Linq;
public interface IFilm
{
    string Title { get; set; }
}
public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }

    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }
}
public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}
public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> films = new List<IFilm>();
    public void AddFilm(IFilm film)
    {
        films.Add(film);
    }
    public void RemoveFilm(string title)
    {
        IFilm film = films.FirstOrDefault(f => f.Title == title);
        if (film != null)
        {
            films.Remove(film);
        }
    }
    public List<IFilm> GetFilms()
    {
        return films;
    }
    public List<IFilm> SearchFilms(string query)
    {
        return films
            .Where(f =>
                f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                (f is Film film && film.Director.Contains(query, StringComparison.OrdinalIgnoreCase))
            ).ToList();
    }

    public int GetTotalFilmCount()
    {
        return films.Count;
    }
}
public class DefaultSolution
{
    public static void Main(string[] args)
    {
        IFilmLibrary library = new FilmLibrary();

        // TEST CASE 1: Adding films
        Console.WriteLine("TEST CASE 1: Adding films");

        Film f1 = new Film("Inception", "Christopher Nolan", 2010);
        Film f2 = new Film("Interstellar", "Christopher Nolan", 2014);
        Film f3 = new Film("Titanic", "James Cameron", 1997);

        library.AddFilm(f1);
        library.AddFilm(f2);
        library.AddFilm(f3);

        Console.WriteLine("Films added successfully\n");

        // TEST CASE 2: Display all films
        Console.WriteLine("TEST CASE 2: Displaying all films");
        foreach (Film film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} | {film.Director} | {film.Year}");
        }
        Console.WriteLine();

        // TEST CASE 3: Search films by director
        Console.WriteLine("TEST CASE 3: Search films by director 'Nolan'");
        List<IFilm> searchResult = library.SearchFilms("Nolan");
        foreach (Film film in searchResult)
        {
            Console.WriteLine($"{film.Title} | {film.Director}");
        }
        Console.WriteLine();

        // TEST CASE 4: Remove a film
        Console.WriteLine("TEST CASE 4: Removing film 'Titanic'");
        library.RemoveFilm("Titanic");

        Console.WriteLine("Remaining films:");
        foreach (Film film in library.GetFilms())
        {
            Console.WriteLine(film.Title);
        }
        Console.WriteLine();

        // TEST CASE 5: Total film count
        Console.WriteLine("TEST CASE 5: Total film count");
        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());
    }
}
