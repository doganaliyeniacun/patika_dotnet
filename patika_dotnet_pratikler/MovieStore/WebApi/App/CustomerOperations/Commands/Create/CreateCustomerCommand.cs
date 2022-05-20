using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.CustomerOperations.Commands.Create
{
    public class CreateCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CustomerModel Model;

        public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var result = _mapper.Map<Customer>(Model);

            _context.Customers.Add(result);
            _context.SaveChanges();
        }
    }

    public class CustomerModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}