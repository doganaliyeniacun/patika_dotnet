using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.ProductOperations.Commands.Delete
{
    public class DeleteProduct
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;        
        public int Id;

        public DeleteProduct(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Product product = _dbContext.Products.SingleOrDefault(s => s.Id == Id);
            if(product is null)
                throw new InvalidOperationException("Ürün bulunamadı.");
            
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}