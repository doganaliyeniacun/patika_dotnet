namespace WebApi.Controllers
{
    using System.ComponentModel;
    using AutoMapper;
    using FluentValidation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.App.CustomerOperations.Commands.Create;
    using WebApi.App.CustomerOperations.Commands.Delete;
    using WebApi.App.CustomerOperations.Commands.TokenOperations;
    using WebApi.App.CustomerOperations.Commands.Update;
    using WebApi.App.CustomerOperations.Queries.Get;
    using WebApi.App.CustomerOperations.Queries.GetDetail;
    using WebApi.DbOperations;
    using WebApi.TokenOperations.Model;

    [Route("[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public CustomerController(IECommerceDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            GetCustomers query = new GetCustomers(_dbContext, _mapper);
            List<CustomerViewModel>? result = query.Handle();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            GetCustomersDetail query = new GetCustomersDetail(_dbContext, _mapper);
            query.Id = id;

            CustomerViewModel result = query.Handle();

            GetCustomerDetailValidator validator = new GetCustomerDetailValidator();
            validator.ValidateAndThrow(query);

            return Ok(result);
        }


        [HttpPost]
        public IActionResult Create([FromBody] CustomerModel model)
        {
            CreateCustomer command = new CreateCustomer(_dbContext,_mapper);
            command.model = model;

            CreateCustomerValidator validator = new CreateCustomerValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CustomerModel model, int id)
        {
            UpdateCustomer command = new UpdateCustomer(_dbContext,_mapper);
            command.model = model;
            command.Id = id;

            UpdateCustomerValidator validator = new UpdateCustomerValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteCustomer command = new DeleteCustomer(_dbContext,_mapper);            
            command.Id = id;

            DeleteCustomerValidator validator = new DeleteCustomerValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
        
        [HttpPost("connect/token")]
        public IActionResult CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_dbContext, _mapper, _configuration);
            command.Model = login;
            Token token = command.Handle();

            return Ok(token);
        }

        [HttpGet("refreshToken")]
        public IActionResult RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_dbContext , _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();

            return Ok(resultToken);
        }
    }
}