using Microsoft.EntityFrameworkCore;
using WebApiEf.DbOperations;

namespace WebApiEf.Application.AuthorOperations.Command.Delete
{
    public class DeleteAuthorCommand
    {
        public int Id { get; set; }
        private readonly IBookStoreDbContext _context;

        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var command = _context.Author.SingleOrDefault(x => x.Id == Id);
            if (command is null)
                throw new InvalidOperationException("Yazar bulunamadı.");

            var checkAuthor = _context.Books.SingleOrDefault(x=> x.AuthorId == Id);

            if (checkAuthor is not null)
                throw new InvalidOperationException("Yazarın kitabı yayında önce yayında olan kitabı siliniz.");

            _context.Author.Remove(command);
            _context.SaveChanges();
        }

    }


}