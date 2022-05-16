using AutoMapper;
using WebApi.App.ActorOperations.Queries.Get;
using WebApi.App.MovieOperations.Commands.Create;
using WebApi.App.MovieOperations.Queries.Get;
using WebApi.Entites;

namespace WebApi.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public  MappingProfile()
        {
            CreateMap<Movie,MovieQueryViewModel>().ForMember(dest => dest.Actors, opt => opt.MapFrom(x => x.Actors.Name +" "+ x.Actors.SurName));
            //CreateMap<Movie,MovieQueryViewModel>();
            CreateMap<CreateMovieModel,Movie>();
            CreateMap<Actor,GetActorsQueryViewModel>();                      
        }
    }
}