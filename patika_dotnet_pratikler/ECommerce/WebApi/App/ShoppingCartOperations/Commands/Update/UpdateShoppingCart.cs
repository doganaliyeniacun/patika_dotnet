using System.Runtime.InteropServices;
using AutoMapper;
using WebApi.App.CustomerOperations.Commands.Create;
using WebApi.App.ProductOperations.Commands.Create;
using WebApi.App.ShoppingCartOperations.Commands.Create;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.ShoppingCartOperations.Commands.Update
{
    public class UpdateShoppingCart
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;        
        public ShoppingCartModel model;
        public int Id;

        public UpdateShoppingCart(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            ShoppingCart shoppingCart = _dbContext.ShoppingCarts.SingleOrDefault(s => s.Id == Id);
            if(shoppingCart is null)
                throw new InvalidOperationException("Sepette ürün bulunamadı.");
            
            shoppingCart.CustomerId = model.CustomerId == default ? shoppingCart.CustomerId : model.CustomerId;
            shoppingCart.ProductId = model.ProductId == default ? shoppingCart.ProductId : model.ProductId;           

            _dbContext.ShoppingCarts.Update(shoppingCart);
            _dbContext.SaveChanges();
        }
    }
}