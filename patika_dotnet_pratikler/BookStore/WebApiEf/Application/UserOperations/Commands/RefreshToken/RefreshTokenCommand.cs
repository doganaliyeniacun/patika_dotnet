using AutoMapper;
using WebApiEf.Application.UserOperations.Commands.CreateToken;
using WebApiEf.DbOperations;
using WebApiEf.TokenOperations;
using WebApiEf.TokenOperations.Models;

namespace WebApiEf.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
         public string RefreshToken { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        

        public RefreshTokenCommand(IBookStoreDbContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccesToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                
                return token;
            }
            else
            {
                throw new InvalidOperationException("Geçerli bir refresh token bulunamadı.");
            }
        }
    }
}