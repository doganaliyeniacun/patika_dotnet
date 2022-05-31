using System.Security.AccessControl;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.App.CustomerOperations.Queries.Get
{  
    public class GetCustomers
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCustomers(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<CustomerViewModel> Handle()
        {
            var customers = _dbContext.Customers.Include(i=> i.ShoppingCart).ThenInclude(t=> t.Product).OrderBy(x=> x.Id).ToList();
            List<CustomerViewModel> vm = _mapper.Map<List<CustomerViewModel>>(customers);

            return vm;
        }
    }

    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public ICollection<string> ShoppingCart { get; set; }
    }
    
}