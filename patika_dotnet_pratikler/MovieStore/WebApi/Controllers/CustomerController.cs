using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.CustomerOperations.Commands.Create;
using WebApi.App.CustomerOperations.Commands.Delete;
using WebApi.App.CustomerOperations.Commands.Update;
using WebApi.App.CustomerOperations.Queries.Get;
using WebApi.App.CustomerOperations.Queries.GetDetail;
using WebApi.App.DirectorOperations.Commands.Create;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            GetCustomerQuery query = new GetCustomerQuery(_context,_mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerDetail(int id)
        {
            GetCustomerQueryDetail query = new GetCustomerQueryDetail(_context,_mapper);
            query.Id = id;

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerModel model)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context,_mapper);
            command.Model = model;

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromBody] CustomerModel model, int id)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            command.Model = model;
            command.Id = id;

            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);            
            command.Id = id;

            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}