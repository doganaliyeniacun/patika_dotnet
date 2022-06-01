using System.Runtime.InteropServices;
using AutoMapper;
using WebApi.App.CustomerOperations.Commands.Create;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.CustomerOperations.Commands.Update
{
    public class UpdateCustomer
    {
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;        
        public CustomerModel model;
        public int Id;

        public UpdateCustomer(IECommerceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            Customer customer = _dbContext.Customers.FirstOrDefault(f => f.Id == Id);
            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı.");
            
            customer.Name = model.Name == default ? customer.Name : model.Name;
            customer.SurName = model.SurName == default ? customer.SurName : model.SurName;
            customer.Email = model.Email == default ? customer.Email : model.Email;
            customer.Password = model.Password == default ? customer.Password : model.Password;

            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }
    }
}