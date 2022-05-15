using WebApiEf.DbOperations;

namespace WebApiEf.Application.CreateBook.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _context;

        public int BookId { get; set; }

        public DeleteBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);

            if(book is null)
                throw new InvalidOperationException("Silinecek kitap bulunamadı!");
            
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}