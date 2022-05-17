using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.MovieOperations.Commands.Update
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _context;

        public UpdateMovieModel Model { get; set; }
        public int Id { get; set; }

        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            Movie movie = _context.Movies.SingleOrDefault(x => x.Id == Id);
            
            if (movie is null)
                throw new InvalidOperationException("Güncellenecek film bulunamadı.");
                        
            movie.DirectorId = movie.DirectorId == default ? movie.DirectorId : Model.DirectorId;
            movie.GenreId = movie.GenreId == default ? movie.GenreId : Model.GenreId;
            movie.PublishDate = movie.PublishDate == default ? movie.PublishDate : Model.PublishDate;
            movie.Price = movie.Price == default ? movie.Price : Model.Price;

            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
    }

    public class UpdateMovieModel
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int ActorsId { get; set; }
        public int Price { get; set; }
    }
}