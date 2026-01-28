using System;
using System.Collections.Generics;
using System.Collections;
namespace Movie
{
    public interface IFilm
    {
        string Title{get; set;}
        string Director{get; set;}
        int Year{get; set;}
    }
    public class Film: IFilm
    {
        public string Title{get; set;}
        public string Director{get; set;}
        public int Year{get; set;}

        public Film(string title, string director, int year)
        {
            Title=title;
            Director=director;
            Year=year;
        }
    }
    public interface IFilmLibrary
    {
        void AddFilm(IFilm Film);
        void RemoveFilm(string title);
    }
    public class FilmLibrary:IFilmLibrary
    {
        private List<IFilm> _films = new List<>();
        
    }
}