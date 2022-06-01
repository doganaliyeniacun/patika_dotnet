using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.App.CustomerOperations.Queries.Get;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.CustomerOperations.Queries.GetDetail
{
    public class GetCustomersDetail
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCustomersDetail(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Id { get; set; }

        public CustomerViewModel Handle()
        {
            Customer customer = _dbContext.Customers.Include(i=> i.ShoppingCart).ThenInclude(t=> t.Product).SingleOrDefault(s => s.Id == Id);
            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı.");

            CustomerViewModel vm = _mapper.Map<CustomerViewModel>(customer);

            return vm;
        }
    }
}