namespace WebApi.Controllers
{
    using AutoMapper;
    using FluentValidation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.App.ShoppingCartOperations.Commands.Create;
    using WebApi.App.ShoppingCartOperations.Commands.Delete;
    using WebApi.App.ShoppingCartOperations.Commands.Update;
    using WebApi.App.ShoppingCartOperations.Queries.Get;
    using WebApi.App.ShoppingCartOperations.Queries.GetDetail;
    using WebApi.DbOperations;

    [Authorize]
    [Route("[controller]s")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public ShoppingCartController(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GetShoppingCarts query = new GetShoppingCarts(_dbContext, _mapper);
            List<ShoppingCartViewModel> result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            GetShoppingCartDetail query = new GetShoppingCartDetail(_dbContext, _mapper);
            query.Id = id;

            ShoppingCartViewModel result = query.Handle();

            GetShoppingCartDetailValidator validator = new GetShoppingCartDetailValidator();
            validator.ValidateAndThrow(query);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ShoppingCartModel model)
        {
            CreateShoppingCart command = new CreateShoppingCart(_dbContext, _mapper);
            command.model = model;

            CreateShoppingCartValidator validator = new CreateShoppingCartValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ShoppingCartModel model, int id)
        {
            UpdateShoppingCart command = new UpdateShoppingCart(_dbContext, _mapper);
            command.model = model;
            command.Id = id;

            UpdateShoppingCartValidator validator = new UpdateShoppingCartValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteShoppingCart command = new DeleteShoppingCart(_dbContext, _mapper);
            command.Id = id;

            DeleteShoppingCartValidator validator = new DeleteShoppingCartValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}