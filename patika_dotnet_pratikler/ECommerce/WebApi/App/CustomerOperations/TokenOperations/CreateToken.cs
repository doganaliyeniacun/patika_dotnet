using AutoMapper;
using WebApi.DbOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Model;

namespace WebApi.App.CustomerOperations.Commands.TokenOperations
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public CreateTokenCommand(IECommerceDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccesToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanıcı adı veya şifre hatalı!");
            }
        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}