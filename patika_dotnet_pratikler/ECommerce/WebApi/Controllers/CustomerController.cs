namespace WebApi.Controllers
{
    using System.ComponentModel;
    using AutoMapper;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.App.CustomerOperations.Commands.Create;
    using WebApi.App.CustomerOperations.Commands.Delete;
    using WebApi.App.CustomerOperations.Commands.Update;
    using WebApi.App.CustomerOperations.Queries.Get;
    using WebApi.App.CustomerOperations.Queries.GetDetail;
    using WebApi.DbOperations;

    [Route("[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomerController(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GetCustomers query = new GetCustomers(_dbContext, _mapper);
            List<CustomerViewModel>? result = query.Handle();

            return Ok(result);
        }

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
    }
}