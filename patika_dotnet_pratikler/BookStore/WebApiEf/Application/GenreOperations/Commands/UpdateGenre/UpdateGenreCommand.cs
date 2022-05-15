using AutoMapper;
using WebApiEf.DbOperations;
using WebApiEf.Entities;

namespace WebApiEf.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IBookStoreDbContext _context;

        public UpdateGenreModel Model { get; set; }

        public int GenreId { get; set; }

        
        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            Genre genre = _context.Genres.SingleOrDefault(x=> x.Id == GenreId);
            if(genre is null)
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı.");


            genre.Name = string.IsNullOrEmpty(Model.Name) ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive;
    
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}