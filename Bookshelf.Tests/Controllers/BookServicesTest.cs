
using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using Bookshelf.Services.Abstractions;
using Bookshelf.Models;
using Microsoft.AspNetCore.Mvc;
using Bookshelf.ViewModels;

namespace Bookshelf.Controllers.Tests.UnitTests
{
    public class BookServicesTest
    {
        [Fact]
        public void Get_ReturnsOkObjectResult_WithABook()
        {
            int bookId = 1;
            var mockRepo = new Mock<IBookServices>();
            mockRepo.Setup(repo => repo.Get(bookId))
                .Returns(ABook());

            var controller = new BookController(mockRepo.Object);
            var result = controller.Get(bookId);
           
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnBook = Assert.IsType<Book>(okObjectResult.Value);

            Assert.Equal(200, okObjectResult.StatusCode);

            Assert.Equal(bookId, returnBook.Id);
        }

        [Fact]
        public void Create_ReturnsOkObjectResult_WithABook() 
        {
            var createBook = ACreateBookDto();
            var book = new Book {
                Title = createBook.Title
            };

            var mockRepo = new Mock<IBookServices>();
             mockRepo.Setup(repo => repo.Create(createBook))
                .Returns(book)
                .Verifiable();

            var controller = new BookController(mockRepo.Object);
            var result = controller.Create(createBook);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnBook = Assert.IsType<Book>(okObjectResult.Value);

            mockRepo.Verify();

            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.Equal(createBook.Title, returnBook.Title);
        }

         [Fact]
        public void Upate_ReturnsOkObjectResult_WithABook() 
        {
            int bookId = 1;

            var createBook = ACreateBookDto();
            var book = ABook();
            book.Title = createBook.Title;

            var mockRepo = new Mock<IBookServices>();
            mockRepo.Setup(repo => repo.Update(bookId, createBook))
                .Returns(book);

            var controller = new BookController(mockRepo.Object);
            var result = controller.Update(bookId, createBook);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnBook = Assert.IsType<Book>(okObjectResult.Value);

            mockRepo.Verify();

            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.Equal(createBook.Title, returnBook.Title);
        }

        private List<Book> GetTestBooks()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book()
            {
                Id = 1,
                Title = "Educated",
                Description = ""
            });
            books.Add(new Book()
            {
                Id = 2,
                Title = "The Hobbit",
                Description = "The description"
            });
            return books;
        }

        private Book ABook()
        {
            string title = "Xunit test book";
            return new Book()
            {
                Id = 1,
                Title = title
            };
        }

        private CreateBookDto ACreateBookDto()
        {
            string title = "New Xunit test book (1)";
            return new CreateBookDto()
            {
                Title = title
            };
        }
    }


}