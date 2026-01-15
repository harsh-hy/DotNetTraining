using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace MovieStock{
public class Movie
{
    public string? Title { get; set; }
    public string? Artist { get; set; }
    public string? Genre { get; set; }
    public int Ratings { get; set; }
}
class Program
{
    public static List<Movie> MovieList = new List<Movie>();
    public void AddMovie(string MovieDetails)
    {
        string[] MovieArray = MovieDetails.Split(",");
        Movie movie = new Movie();
        movie.Title = MovieArray[0];
        movie.Artist = MovieArray[1];
        movie.Genre = MovieArray[2];
        movie.Ratings = int.Parse(MovieArray[3].Trim());
        MovieList.Add(movie);
    }
    public List<Movie> ViewMovieByGenre(string? genre)
    {
        return MovieList.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public List<Movie> ViewMovieByRatings()
    {
        return MovieList.OrderBy(m => m.Ratings).ToList();
    }
    public static void Main()
    {
        Program p = new Program();
        Console.WriteLine("Enter number of movies:");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter movie details (Title,Artist,Genre,Ratings):");
            string details = Console.ReadLine();
            p.AddMovie(details);
        }
        Console.WriteLine("Enter genre to search:");
        string searchGenre = Console.ReadLine();

        Console.WriteLine("Movies By Genre");
        List<Movie> byGenre = p.ViewMovieByGenre(searchGenre);
        if (byGenre.Count == 0)
        {
            Console.WriteLine($"No Movies found in genre '{searchGenre}'");
        }
        else
        {
            foreach (var m in byGenre)
            {
                Console.WriteLine($"{m.Title},{m.Artist},{m.Genre},{m.Ratings}");
            }
        }
        Console.WriteLine("Movies Sorted By Ratings");
        List<Movie> byRating = p.ViewMovieByRatings();
        foreach (var m in byRating)
        {
            Console.WriteLine($"{m.Title},{m.Artist},{m.Genre},{m.Ratings}");
        }
    }
}
}