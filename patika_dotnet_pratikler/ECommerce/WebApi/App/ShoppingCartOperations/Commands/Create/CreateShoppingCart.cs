using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.ShoppingCartOperations.Commands.Create
{
    public class CreateShoppingCart
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public ShoppingCartModel model;

        public CreateShoppingCart(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Id == model.CustomerId);
            Product product = _dbContext.Products.SingleOrDefault(s => s.Id == model.ProductId);

            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            else if (product is null)
                throw new InvalidOperationException("Ürün bulunamadı!");

            ShoppingCart shoppingCart = _mapper.Map<ShoppingCart>(model);

            _dbContext.ShoppingCarts.Add(shoppingCart);
            _dbContext.SaveChanges();
        }
    }

    public class ShoppingCartModel
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
}