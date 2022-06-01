namespace WebApi.Controllers
{
    using AutoMapper;
    using FluentValidation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.App.ProductOperations.Commands.Create;
    using WebApi.App.ProductOperations.Commands.Delete;
    using WebApi.App.ProductOperations.Commands.Update;
    using WebApi.App.ProductOperations.Queries.Get;
    using WebApi.App.ProductOperations.Queries.GetDetail;
    using WebApi.DbOperations;

    [Authorize]
    [Route("[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductController(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GetProducts query = new GetProducts(_dbContext, _mapper);
            List<ProductViewModel>? result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail(int id)
        {
            GetProductDetail query = new GetProductDetail(_dbContext, _mapper);
            query.Id = id;

            ProductViewModel result = query.Handle();

            GetProductDetailValidator validator = new GetProductDetailValidator();
            validator.ValidateAndThrow(query);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductModel model)
        {
            CreateProduct command = new CreateProduct(_dbContext, _mapper);
            command.model = model;

            CreateProductValidator validator = new CreateProductValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ProductModel model, int id)
        {
            UpdateProduct command = new UpdateProduct(_dbContext, _mapper);
            command.model = model;
            command.Id = id;

            UpdateProductValidator validator = new UpdateProductValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DeleteProduct command = new DeleteProduct(_dbContext, _mapper);
            command.Id = id;

            DeleteProductValidator validator = new DeleteProductValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
    }
}