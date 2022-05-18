using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.MovieOperations.Commands.Create
{
    public class CreateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieModel Model;

        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            Movie movie = _context.Movies.SingleOrDefault(x => x.Name.Trim().ToLower() == Model.Name.Trim().ToLower());
            if (movie is not null)
                throw new InvalidOperationException("Film zaten mevcut!");

            movie = _mapper.Map<Movie>(Model);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            ActorMovies actorMovie = new ActorMovies();
            actorMovie.MovieId = movie.Id;
            actorMovie.ActorId = Model.ActorsId;
            
            _context.ActorMovies.Add(actorMovie);
            _context.SaveChanges();
        }
    }

    public class CreateMovieModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int ActorsId { get; set; }
        public int Price { get; set; }
    }
}