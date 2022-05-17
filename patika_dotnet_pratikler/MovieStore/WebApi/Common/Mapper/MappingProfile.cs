using AutoMapper;
using WebApi.App.ActorOperations.Commands.Create;
using WebApi.App.ActorOperations.Commands.Update;
using WebApi.App.ActorOperations.Queries.Get;
using WebApi.App.MovieOperations.Commands.Create;
using WebApi.App.MovieOperations.Queries.Get;
using WebApi.Entites;

namespace WebApi.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieQueryViewModel>().ForMember(dest=> dest.Actors, opt=> opt.MapFrom(m=> m.ActorMovies.Select(s=> s.Actor.Name + " " + s.Actor.SurName)));
            CreateMap<CreateMovieModel,Movie>();

            CreateMap<Actor, GetActorsQueryViewModel>();
            CreateMap<CreateActorModel, Actor>();
        }        
    }
}