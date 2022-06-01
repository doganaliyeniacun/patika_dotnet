using System.Runtime.InteropServices;
using AutoMapper;
using WebApi.App.CustomerOperations.Commands.Create;
using WebApi.App.ProductOperations.Commands.Create;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.ProductOperations.Commands.Update
{
    public class UpdateProduct
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;        
        public ProductModel model;
        public int Id;

        public UpdateProduct(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Product product = _dbContext.Products.SingleOrDefault(s => s.Id == Id);
            if(product is null)
                throw new InvalidOperationException("Ürün bulunamadı.");
            
            product.ProductName = model.ProductName == default ? product.ProductName : model.ProductName;
            product.GenreId = model.GenreId == default ? product.GenreId : model.GenreId;
            product.Price = model.Price == default ? product.Price : model.Price;            

            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }
    }
}