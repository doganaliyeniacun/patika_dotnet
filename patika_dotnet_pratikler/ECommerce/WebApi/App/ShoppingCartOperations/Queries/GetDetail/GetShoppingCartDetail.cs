using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.App.CustomerOperations.Queries.Get;
using WebApi.App.ProductOperations.Queries.Get;
using WebApi.App.ShoppingCartOperations.Queries.Get;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.ShoppingCartOperations.Queries.GetDetail
{
    public class GetShoppingCartDetail
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetShoppingCartDetail(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Id { get; set; }

        public ShoppingCartViewModel Handle()
        {                        
            var shoppingCart = _dbContext.Customers.Include(i => i.ShoppingCart).ThenInclude(t => t.Product).SingleOrDefault(x => x.Id == Id);
            if (shoppingCart is null)
                throw new InvalidOperationException("Sepet bulunamadı.");

            ShoppingCartViewModel vm = _mapper.Map<ShoppingCartViewModel>(shoppingCart);
            

            return vm;
        }
    }
}