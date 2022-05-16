using Microsoft.EntityFrameworkCore;
using WebApi.Entites;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {

                context.Movies.AddRange(
                    new Movie
                    {
                        Name = "test",
                        DirectorId = 1,
                        //ActorsId = 1,
                        GenreId = 1,
                        Price = 100,
                        PublishDate = new DateTime(1997, 01, 07),

                    },
                    new Movie
                    {
                        Name = "test2",
                        DirectorId = 2,
                        //ActorsId = 3,
                        GenreId = 2,
                        Price = 200,
                        PublishDate = new DateTime(1999, 08, 28),
                    },
                    new Movie
                    {
                        Name = "test3",
                        DirectorId = 3,
                        //ActorsId = 3,
                        GenreId = 3,
                        Price = 300,
                        PublishDate = new DateTime(2022, 05, 01),
                    },
                    new Movie
                    {
                        Name = "test4",
                        DirectorId = 3,
                        //ActorsId = 3,
                        GenreId = 3,
                        Price = 300,
                        PublishDate = new DateTime(2022, 05, 01),
                    }
                );

                context.Actors.AddRange(
                    new Actor
                    {
                        Name = "actor1",
                        SurName = "actorSurname1",
                        MovieId = 1

                    },
                    new Actor
                    {
                        Name = "actor2",
                        SurName = "actorSurname2",
                        MovieId = 1
                    },
                    new Actor
                    {
                        Name = "actor3",
                        SurName = "actorSurname3",
                        MovieId = 2
                    },
                    new Actor
                    {
                        Name = "actor3",
                        SurName = "actorSurname3",
                        MovieId = 3
                    }
                );

                context.SaveChanges();
            }
        }
    }
}