using AutoMapper;
using WebApi.DbOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Model;

namespace WebApi.App.CustomerOperations.Commands.TokenOperations
{
     public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IECommerceDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        

        public RefreshTokenCommand(IECommerceDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
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
                throw new InvalidOperationException("Geçerli bir refresh token bulunamadı.");
            }
        }
    }
}