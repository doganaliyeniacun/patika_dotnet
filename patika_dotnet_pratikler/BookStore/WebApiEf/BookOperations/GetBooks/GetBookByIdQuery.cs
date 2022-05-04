using WebApiEf.Common;
using WebApiEf.DbOperations;

namespace WebApiEf.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _context;

        public GetBookByIdQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public GetBookByIdViewModel Handle(int id)
        {
            Book book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            GetBookByIdViewModel bookViewModel = new GetBookByIdViewModel();

            bookViewModel.Title = book.Title;
            bookViewModel.PageCount = book.PageCount;
            bookViewModel.PublishDate = book.PublishDate.ToString("dd/mm/yyyy");
            bookViewModel.Genre = ((GenreEnum)book.GenreId).ToString();

            return bookViewModel;
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