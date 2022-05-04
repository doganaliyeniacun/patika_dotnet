using Microsoft.AspNetCore.Mvc;
using WebApiEf.BookOperations;
using WebApiEf.BookOperations.CreateBook;
using WebApiEf.BookOperations.GetBooks;
using WebApiEf.BookOperations.UpdateBook;
using WebApiEf.DbOperations;
using static WebApiEf.BookOperations.CreateBook.CreateBookCommand;
using static WebApiEf.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApiEf.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new GetBookQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery getBookByIdQuery = new GetBookByIdQuery(_context);

            try
            {
                var result = getBookByIdQuery.Handle(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // [HttpGet]
        // public Book Get([FromQuery] int id)
        // {            
        //     Book book = _context.Books.Where(x=> x.Id == id).SingleOrDefault<Book>();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel bookModel)
        {
            CreateBookCommand command = new CreateBookCommand(_context);

            try
            {
                command.Model = bookModel;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.Model = updatedBook;
                command.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();

            _context.Books.Remove(book);

            _context.SaveChanges();
            return Ok();

        }
    }
}
