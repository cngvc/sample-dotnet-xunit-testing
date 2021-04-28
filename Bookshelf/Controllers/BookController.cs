using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bookshelf.Models;
using Bookshelf.ViewModels;
using Bookshelf.Services.Abstractions;

namespace Bookshelf.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _service;
        public BookController(IBookServices bookServices)
        {
            _service = bookServices;
        }

        [Route("api/books")]
        [HttpGet]
        public ActionResult GetItems()
        {
            var books = _service.GetItems();
            return Ok(books);
        }

        [Route("api/books")]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var book = _service.Get(id);
            return Ok(book);
        }

        [Route("api/books")]
        [HttpPost]
        public ActionResult Create([FromBody] CreateBookDto data)
        {
            var book = _service.Create(data);
            return Ok(book);
        }

        [Route("api/books")]
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CreateBookDto data)
        {
            var book = _service.Update(id, data);
            return Ok(book);
        }
    }
}