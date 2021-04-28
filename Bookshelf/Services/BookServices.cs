using System.Collections.Generic;
using System.Linq;
using Bookshelf.Services.Abstractions;
using Bookshelf.Models;
using Bookshelf.ViewModels;

namespace Bookshelf.Services
{
    public class BookServices : IBookServices
    {
        private readonly DatabaseContext _database;

        public BookServices(DatabaseContext database)
        {
            _database = database;
        }
        
        public List<Book> GetItems(){
            return _database.Books.ToList();
        }

        public Book Get(int id){
            return _database.Books.FirstOrDefault(book => book.Id == id);
        }

        public Book Create(CreateBookDto data){
           Book book = new Book {
                Title = data.Title,
                Description = data.Description
            };
            _database.Books.Add(book);
            _database.SaveChanges();
            return book;
        }

        public Book Update(int id, CreateBookDto data){
            Book book = _database.Books.FirstOrDefault(book => book.Id == id);
            book.Title = data.Title;
            book.Description = data.Description;
            _database.Books.Update(book);
            _database.SaveChanges();
            return book;
        }
    }
}