using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.ActorOperations.Queries.Get;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActor()
        {
            GetActorsQuery query = new GetActorsQuery(_context,_mapper);
            var result = query.Handle();

            return Ok(result);
        }
    }
}