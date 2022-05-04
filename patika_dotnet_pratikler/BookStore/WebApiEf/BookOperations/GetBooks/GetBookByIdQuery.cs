using AutoMapper;
using WebApiEf.Common;
using WebApiEf.DbOperations;

namespace WebApiEf.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetBookByIdViewModel Handle(int id)
        {
            Book book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            GetBookByIdViewModel vm = _mapper.Map<GetBookByIdViewModel>(book);

            return vm;
        }

        public class GetBookByIdViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string Genre { get; set; }
            public string PublishDate { get; set; }
        }
    }
}