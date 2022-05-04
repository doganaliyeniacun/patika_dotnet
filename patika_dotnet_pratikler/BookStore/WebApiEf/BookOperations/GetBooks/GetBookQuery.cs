using WebApiEf.Common;
using WebApiEf.DbOperations;

namespace WebApiEf.BookOperations
{
    public class GetBookQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBookQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum) book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount,
                });
            }
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