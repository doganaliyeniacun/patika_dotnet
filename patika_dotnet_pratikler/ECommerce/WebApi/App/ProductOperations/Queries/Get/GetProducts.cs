using System.Security.AccessControl;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.App.ProductOperations.Queries.Get
{  
    public class GetProducts
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProducts(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ProductViewModel> Handle()
        {
            var products = _dbContext.Products.OrderBy(x=> x.Id).ToList();
            List<ProductViewModel> vm = _mapper.Map<List<ProductViewModel>>(products);

            return vm;
        }
    }

    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }   
    }
    
}