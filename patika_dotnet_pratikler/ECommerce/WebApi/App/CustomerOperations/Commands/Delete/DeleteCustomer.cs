using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.CustomerOperations.Commands.Delete
{
    public class DeleteCustomer
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;        
        public int Id;

        public DeleteCustomer(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Id == Id);
            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı.");
            
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}