using Microsoft.EntityFrameworkCore;
using WebApiEf.Entities;

namespace WebApiEf.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Author.AddRange(
                    new Author
                    {
                        Name = "Doğan Ali",
                        SurName = "Yeniacun",
                        Birthday = new DateTime(1997,01,07)
                    },
                    new Author
                    {
                        Name = "Veli",
                        SurName = "Baş",
                        Birthday = new DateTime(2001,03,05)
                    },
                    new Author
                    {
                        Name = "Melih",
                        SurName = "Şen",
                        Birthday = new DateTime(1976,06,01)
                    }

                );
                
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(

                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, 
                        AuthorId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 21)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2, 
                        AuthorId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 1,
                        AuthorId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2002, 05, 03)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}