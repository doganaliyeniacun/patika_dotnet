using WebApiEf.DbOperations;

namespace WebApiEf.Application.CreateBook.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        private readonly IBookStoreDbContext _context;

        public UpdateBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            book.Title = Model.Title != "string" ? Model.Title : book.Title;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;

            _context.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public int GenreId { get; set; }
            public int AuthorId { get; set; }
        }
    }
}