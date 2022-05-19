using AutoMapper;
using WebApi.App.ActorMoviesOperation.Command.Create;
using WebApi.App.ActorMoviesOperation.Command.Update;
using WebApi.App.ActorMoviesOperation.Queries.Get;
using WebApi.App.ActorOperations.Commands.Create;
using WebApi.App.ActorOperations.Commands.Update;
using WebApi.App.ActorOperations.Queries.Get;
using WebApi.App.MovieOperations.Commands.Create;
using WebApi.App.MovieOperations.Queries.Get;
using WebApi.Common.Enums.GenreEnums;
using WebApi.Entites;

namespace WebApi.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieQueryViewModel>()
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(m => m.ActorMovies.Select(s => s.Actor.Name + " " + s.Actor.SurName)))
                .ForMember(dest=> dest.Genre, opt=> opt.MapFrom(m=> (GenreEnums)m.GenreId));
            CreateMap<CreateMovieModel, Movie>();

            CreateMap<Actor, GetActorsQueryViewModel>();
            CreateMap<CreateActorModel, Actor>();

            CreateMap<Actor, GetActorMovieViewModel>()
                .ForMember(dest => dest.NameSurName, opt => opt.MapFrom(m => m.Name + " " + m.SurName))
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.ActorMovies.Select(s => s.Movie.Name)));

            CreateMap<CreateActorMovieModel, ActorMovies>();               
        }
    }
}