using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.App.CustomerOperations.Queries.Get;
using WebApi.App.ProductOperations.Queries.Get;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.ProductOperations.Queries.GetDetail
{
    public class GetProductDetail
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProductDetail(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Id { get; set; }

        public ProductViewModel Handle()
        {
            Product product = _dbContext.Products.SingleOrDefault(s => s.Id == Id);
            if(product is null)
                throw new InvalidOperationException("Ürün bulunamadı.");
                
            ProductViewModel vm = _mapper.Map<ProductViewModel>(product);

            return vm;
        }
    }
}