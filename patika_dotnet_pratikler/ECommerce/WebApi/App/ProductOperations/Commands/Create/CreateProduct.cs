using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.ProductOperations.Commands.Create
{
    public class CreateProduct
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;        
        public ProductModel model;

        public CreateProduct(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Product product = _dbContext.Products.SingleOrDefault(s => s.ProductName.ToLower() == model.ProductName.ToLower());
            if(product is not null)
                throw new InvalidOperationException("Ürün zaten mevcut.");

            product = _mapper.Map<Product>(model);

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();          
        }
    }

    public class ProductModel
    {
        public string ProductName { get; set; }
        public int GenreId { get; set; }
        public int Price { get; set; } 
    }
}