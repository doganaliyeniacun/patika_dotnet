using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.ShoppingCartOperations.Commands.Delete
{
    public class DeleteShoppingCart
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;        
        public int Id;

        public DeleteShoppingCart(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            ShoppingCart shoppingCart = _dbContext.ShoppingCarts.SingleOrDefault(s => s.Id == Id);
            if(shoppingCart is null)
                throw new InvalidOperationException("Sepette ürün bulunamadı.");
            
            _dbContext.ShoppingCarts.Remove(shoppingCart);
            _dbContext.SaveChanges();
        }
    }
}