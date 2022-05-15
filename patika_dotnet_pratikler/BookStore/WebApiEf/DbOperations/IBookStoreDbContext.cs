using Microsoft.EntityFrameworkCore;
using WebApiEf.Entities;

namespace WebApiEf.DbOperations
{

    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Author { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
