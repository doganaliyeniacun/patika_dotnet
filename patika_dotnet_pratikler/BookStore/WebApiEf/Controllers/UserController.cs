using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiEf.Application.UserOperations.Commands.CreateToken;
using WebApiEf.Application.UserOperations.Commands.CreateUser;
using WebApiEf.Application.UserOperations.Commands.RefreshToken;
using WebApiEf.DbOperations;
using WebApiEf.TokenOperations.Models;
using static WebApiEf.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApiEf.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly   IConfiguration _configuration;

        public UserController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context,_mapper);
            command.Model = newUser;
            command.Handle();

            return Ok(); 
        }

        [HttpPost("connect/token")]
        public IActionResult CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper, _configuration);
            command.Model = login;
            Token token = command.Handle();

            return Ok(token);  
        }

        [HttpGet("refreshToken")]
        public IActionResult RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();

            return Ok(resultToken);  
        }

    }
}