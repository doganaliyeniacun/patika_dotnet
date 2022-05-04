using AutoMapper;
using static WebApiEf.BookOperations.CreateBook.CreateBookCommand;
using static WebApiEf.BookOperations.GetBookQuery;
using static WebApiEf.BookOperations.GetBooks.GetBookByIdQuery;

namespace WebApiEf.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,GetBookByIdViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); //.ForMember(dest => dest.PublishDate,opt => opt.MapFrom(src => src.PublishDate.ToString("dd/mm/yyyy")));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}