using System.Collections.Immutable;
using System.ComponentModel;
using AutoMapper;
using WebApiEf.DbOperations;

namespace WebApiEf.Application.GenreOperations.Queries.GetGenresDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenresDetailViewModel Handle()
        {
            var genres = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genres is null)
                throw new InvalidOperationException("Kitap türü bulunamadı.");
            return _mapper.Map<GenresDetailViewModel>(genres);
        }
    }

    public class GenresDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}