using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApiEf.Application.GenreOperations.Commands.CreateCommand;
using WebApiEf.Application.GenreOperations.Commands.DeleteGenre;
using WebApiEf.Application.GenreOperations.Commands.UpdateGenre;
using WebApiEf.Application.GenreOperations.Queries.GetGenres;
using WebApiEf.Application.GenreOperations.Queries.GetGenresDetail;
using WebApiEf.DbOperations;

namespace WebApiEf.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public IActionResult GetGenresDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();

            query.GenreId = id;
            validator.ValidateAndThrow(query);

            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreModel model)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = model;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Model = model;
            command.GenreId = id;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }


        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

    }


}

