using AutoMapper;
using WebApiEf.Common;
using WebApiEf.DbOperations;

namespace WebApiEf.BookOperations
{
    public class GetBookQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
                        
            return vm;
        }

        public class BooksViewModel
        {
            public string Title { get;set;}
            public int PageCount { get;set;}
            public string PublishDate { get;set;}
            public string Genre { get;set;}
        }
    }
}