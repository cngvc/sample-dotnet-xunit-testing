
using System;
using Moq;
using System.Collections.Generic;
using Xunit;
using Bookshelf.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Services.Tests.UnitTests
{
    public class BookServicesBaseTest
    {
        public DbContextOptions<DatabaseContext> contextOptions = new DbContextOptionsBuilder<DatabaseContext>().UseSqlite("Filename=Bookshelf.db").Options;

        public BookServicesBaseTest()
        {
            Seed();
        }

        private void Seed()
        {
            using (var context = new DatabaseContext(contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.AddRange(
                    new Book
                    {
                        Title = "A Children’s Bible"
                    },
                    new Book
                    {
                        Title = "Deacon King Kong"
                    },
                    new Book
                    {
                        Title = "Homeland Elegies"
                    }
                );
                context.SaveChanges();
            }
        }

        [Fact]
        public void Get_ReturnsBookList()
        {
            using (var context = new DatabaseContext(contextOptions))
            {
                var controller = new BookServices(context);

                var results = controller.GetItems();

                Assert.IsType<List<Book>>(results);

                Assert.Equal(3, results.Count);

                Assert.Equal("A Children’s Bible", results[0].Title);
                Assert.Equal("Deacon King Kong", results[1].Title);
                Assert.Equal("Homeland Elegies", results[2].Title);
            }
        }

        [Fact]
        public void Get_ReturnsABook()
        {
            using (var context = new DatabaseContext(contextOptions))
            {
                int bookId = 1;

                var controller = new BookServices(context);

                var result = controller.Get(bookId);

                Assert.IsType<Book>(result);

                Assert.Equal("A Children’s Bible", result.Title);
            }
        }
    }
}