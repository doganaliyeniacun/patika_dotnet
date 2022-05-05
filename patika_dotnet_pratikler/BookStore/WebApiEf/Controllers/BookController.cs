using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApiEf.BookOperations;
using WebApiEf.BookOperations.CreateBook;
using WebApiEf.BookOperations.DeleteBook;
using WebApiEf.BookOperations.GetBookById;
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

            try
            {
                getBookByIdQuery.Id = id;

                GetBookByIdValidator validator = new GetBookByIdValidator();                
                validator.ValidateAndThrow(getBookByIdQuery);

                var result = getBookByIdQuery.Handle();
                
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
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

            try
            {
                command.Model = bookModel;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);

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
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                
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
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId = id;
                DeleteBookValidator validator = new DeleteBookValidator();
                validator.ValidateAndThrow(command);
                
                command.Handle();
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            return Ok();

        }
    }
}
