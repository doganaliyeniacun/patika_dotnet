using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.CustomerOperations.Queries.Get;
using WebApi.App.PurchasedMoviesOperation.Queries.Get;
using WebApi.App.PurchasedMoviesOperation.Queries.GetDetail;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class PurchasedMovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public PurchasedMovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPurchasedMovies()
        {
            GetPurchasedMoviesQuery query = new GetPurchasedMoviesQuery(_dbContext, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchasedMoviesDetail(int id)
        {
            GetPurchasedMoviesDetailQuery query = new GetPurchasedMoviesDetailQuery(_dbContext, _mapper);
            query.Id = id;

            GetPurchasedMoviesDetailQueryValidator validator = new GetPurchasedMoviesDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var response = query.Handle();

            return Ok(response);
        }

        // [HttpPost]
        // public IActionResult CreateDirectorMovie([FromBody] DirectorMovieModel model)
        // {
        //     CreateDirectorMovieCommand command = new CreateDirectorMovieCommand(_dbContext, _mapper);
        //     command.model = model;

        //     CreateDirectorMovieCommandValidator validator = new CreateDirectorMovieCommandValidator();
        //     validator.ValidateAndThrow(command);

        //     command.Handle();

        //     return Ok();
        // }

        // [HttpPut("{id}")]
        // public IActionResult UpdateDirectorMovie([FromBody] DirectorMovieModel model, int Id)
        // {
        //     UpdateDirectorMovieCommand command = new UpdateDirectorMovieCommand(_dbContext, _mapper);
        //     command.model = model;
        //     command.Id = Id;

        //     UpdateDirectorMovieCommandValidator validator = new UpdateDirectorMovieCommandValidator();
        //     validator.ValidateAndThrow(command);

        //     command.Handle();

        //     return Ok();
        // }

        // [HttpDelete("{id}")]
        // public IActionResult DeleteDirectorMovie(int Id)
        // {
        //     DeleteDirectorMovieCommand command = new DeleteDirectorMovieCommand(_dbContext);        
        //     command.Id = Id;

        //     DeleteDirectorMovieCommandValidator validator = new DeleteDirectorMovieCommandValidator();
        //     validator.ValidateAndThrow(command);

        //     command.Handle();

        //     return Ok();
        // }
    }
}