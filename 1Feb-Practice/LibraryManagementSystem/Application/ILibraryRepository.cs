using Domain;
using System.Collections.Generic;

namespace Application;

public interface ILibraryRepository
{
    void Add(Book book);
    List<Book> GetAll();
}
