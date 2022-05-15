using AutoMapper;
using WebApiEf.DbOperations;
using WebApiEf.Entities;

namespace WebApiEf.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {

        public CreateUserModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            User user = _dbContext.Users.SingleOrDefault(x => x.Email.ToLower() == Model.Email.ToLower());
            if (user is not null)
                throw new InvalidOperationException("Kullanıcı zaten mevcut!");

            user = _mapper.Map<User>(Model);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public class CreateUserModel
        {
            public string Name { get; set; }

            public string SurName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
