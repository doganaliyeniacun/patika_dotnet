using AutoMapper;
using WebApiEf.Application.AuthorOperations.Queries.Get;
using WebApiEf.DbOperations;

namespace WebApiEf.Application.AuthorOperations.Queries.GetDetail
{
    public class GetAuthorDetail
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public int Id { get; set; }

        public GetAuthorDetail(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorViewModel Handle()
        {
            var query = _context.Author.SingleOrDefault(x => x.Id == Id);
            if (query is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            AuthorViewModel vm = _mapper.Map<AuthorViewModel>(query);

            return vm;
        }
    }
}