namespace WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private static List<Book> BookList = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Lean Startup",
                GenreId = 1, // Personal Growth
                PageCount = 200,
                PublishDate = new DateTime(2001,06,21)
            },
            new Book
            {
                Id = 2,
                Title = "Herland",
                GenreId = 2, // Science Fiction
                PageCount = 250,
                PublishDate = new DateTime(2010,05,23)
            },
            new Book
            {
                Id = 3,
                Title = "Dune",
                GenreId = 1, // Science Fiction
                PageCount = 540,
                PublishDate = new DateTime(2002,05,03)
            }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            Book book = BookList.Where(x => x.Id == id).SingleOrDefault<Book>();
            return book;
        }

        // [HttpGet]
        // public Book Get([FromQuery] int id)
        // {            
        //     Book book = BookList.Where(x=> x.Id == id).SingleOrDefault<Book>();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            Book checkBook = BookList.SingleOrDefault(x => x.Title == book.Title);
            if (checkBook is not null)
                return BadRequest();


            BookList.Add(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();

            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();

            BookList.Remove(book);
            return Ok();

        }
    }
}