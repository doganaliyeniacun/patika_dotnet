using System.ComponentModel.Design;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApiEf.Application.AuthorOperations.Command.Create;
using WebApiEf.Application.AuthorOperations.Command.Delete;
using WebApiEf.Application.AuthorOperations.Command.Update;
using WebApiEf.Application.AuthorOperations.Queries.Get;
using WebApiEf.Application.AuthorOperations.Queries.GetDetail;
using WebApiEf.DbOperations;

namespace WebApiEf.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthor()
        {
            GetAuthor query = new GetAuthor(_context, _mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetail query = new GetAuthorDetail(_context, _mapper);
            query.Id = id;

            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel model)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.model = model;

            CreateAuthorValidator validator = new CreateAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel model)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Id = id;
            command.model = model;

            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.Id = id;

            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}