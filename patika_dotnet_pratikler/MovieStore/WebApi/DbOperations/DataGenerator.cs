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
                        //ActorsId = 1,
                        GenreId = 1,
                        Price = 100,
                        PublishDate = new DateTime(1997, 01, 07),

                    },
                    new Movie
                    {
                        Name = "test2",                        
                        //ActorsId = 3,
                        GenreId = 2,
                        Price = 200,
                        PublishDate = new DateTime(1999, 08, 28),
                    },
                    new Movie
                    {
                        Name = "test3",                        
                        //ActorsId = 3,
                        GenreId = 3,
                        Price = 300,
                        PublishDate = new DateTime(2022, 05, 01),
                    },
                    new Movie
                    {
                        Name = "test4",                        
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

                    },
                    new Actor
                    {
                        Name = "actor2",
                        SurName = "actorSurname2",                        
                    },
                    new Actor
                    {
                        Name = "actor3",
                        SurName = "actorSurname3",                        
                    },
                    new Actor
                    {
                        Name = "actor3",
                        SurName = "actorSurname3",                        
                    }
                );

                context.ActorMovies.AddRange(
                    new ActorMovies
                    {
                        ActorId = 1,
                        MovieId = 1
                    },
                    new ActorMovies
                    {
                        ActorId = 1,
                        MovieId = 2
                    },
                    new ActorMovies
                    {
                        ActorId = 2,
                        MovieId = 1
                    },
                    new ActorMovies
                    {
                        ActorId = 3,
                        MovieId = 1
                    },
                    new ActorMovies
                    {
                        ActorId = 4,
                        MovieId = 4
                    }
                );

                context.Directors.AddRange(
                    new Director
                    {
                        Name = "Director1",
                        SurName = "DirectorSurname1",                        

                    },
                    new Director
                    {
                        Name = "Director2",
                        SurName = "DirectorSurname2",                        
                    },
                    new Director
                    {
                        Name = "Director3",
                        SurName = "DirectorSurname3",                        
                    },
                    new Director
                    {
                        Name = "Director3",
                        SurName = "DirectorSurname3",                        
                    }
                );

                context.DirectorMovies.AddRange(
                    new DirectorMovies
                    {
                        DirectorId = 1,
                        MovieId = 1
                    },
                    new DirectorMovies
                    {
                        DirectorId = 2,
                        MovieId = 2
                    },
                    new DirectorMovies
                    {
                        DirectorId = 3,
                        MovieId = 3
                    },
                    new DirectorMovies
                    {
                        DirectorId = 4,
                        MovieId = 4
                    }

                );

                context.SaveChanges();
            }

        }
    }
}