using WebApiEf.DbOperations;

namespace WebApiEf.Application.AuthorOperations.Command.Delete
{
    public class DeleteAuthor
    {
        public int Id { get; set; }
        private readonly BookStoreDbContext _context;

        public DeleteAuthor(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var command = _context.Author.SingleOrDefault(x=> x.Id == Id);
            if (command is null)
                throw new InvalidOperationException("Yazar bulunamadı.");
            
            _context.Author.Remove(command);
            _context.SaveChanges();
        }

    }

    
}