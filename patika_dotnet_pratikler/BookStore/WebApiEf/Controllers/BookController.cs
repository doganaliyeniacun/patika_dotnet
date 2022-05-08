using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApiEf.Application.CreateBook.BookOperations.CreateBook;
using WebApiEf.Application.CreateBook.BookOperations.DeleteBook;
using WebApiEf.Application.CreateBook.BookOperations.UpdateBook;
using WebApiEf.Application.Queries.BookOperations;
using WebApiEf.Application.Queries.BookOperations.GetBookById;
using WebApiEf.Application.Queries.BookOperations.GetBooks;
using WebApiEf.DbOperations;
using static WebApiEf.Application.CreateBook.BookOperations.CreateBook.CreateBookCommand;
using static WebApiEf.Application.CreateBook.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApiEf.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new GetBookQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery getBookByIdQuery = new GetBookByIdQuery(_context, _mapper);


            getBookByIdQuery.Id = id;

            GetBookByIdValidator validator = new GetBookByIdValidator();
            validator.ValidateAndThrow(getBookByIdQuery);

            var result = getBookByIdQuery.Handle();

            return Ok(result);
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
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);


            command.Model = bookModel;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);

            command.Model = updatedBook;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle(id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);

            command.BookId = id;
            DeleteBookValidator validator = new DeleteBookValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}
