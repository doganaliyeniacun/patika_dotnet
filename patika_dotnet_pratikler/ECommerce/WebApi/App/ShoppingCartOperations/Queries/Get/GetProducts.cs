using System.Security.AccessControl;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.App.ShoppingCartOperations.Queries.Get
{  
    public class GetShoppingCarts
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetShoppingCarts(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ShoppingCartViewModel> Handle()
        {
            var shoppingCart = _dbContext.Customers.Include(i => i.ShoppingCart).ThenInclude(t => t.Product).OrderBy(x=> x.Id).ToList();
            List<ShoppingCartViewModel> vm = _mapper.Map<List<ShoppingCartViewModel>>(shoppingCart);

            return vm;
        }
    }

    public class ShoppingCartViewModel
    {
        public string Customer { get; set; }
        public ICollection<string> Products { get; set; }          
    }
    
}