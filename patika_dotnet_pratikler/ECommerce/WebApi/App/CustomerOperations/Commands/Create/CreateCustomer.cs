using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.CustomerOperations.Commands.Create
{
    public class CreateCustomer
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;        
        public CustomerModel model;

        public CreateCustomer(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Email == model.Email);
            if(customer is not null)
                throw new InvalidOperationException("Mail adresi daha önce kullanılmış!");

            customer = _mapper.Map<Customer>(model);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();          
        }
    }

    public class CustomerModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}