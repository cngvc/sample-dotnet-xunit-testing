using System.Collections.Generic;
using Bookshelf.Models;
using Bookshelf.ViewModels;

namespace Bookshelf.Services.Abstractions
{
    public interface IBookServices
    {
        List<Book> GetItems();
        Book Get(int id);
        Book Create(CreateBookDto data);
        Book Update(int id, CreateBookDto data);
    }
}