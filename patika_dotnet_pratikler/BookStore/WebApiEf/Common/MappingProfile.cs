using AutoMapper;
using WebApiEf.Application.AuthorOperations.Command.Create;
using WebApiEf.Application.AuthorOperations.Queries.Get;
using WebApiEf.Application.CreateBook.BookOperations.CreateBook;
using WebApiEf.Application.GenreOperations.Commands.UpdateGenre;
using WebApiEf.Application.GenreOperations.Queries.GetGenres;
using WebApiEf.Application.GenreOperations.Queries.GetGenresDetail;
using WebApiEf.Entities;
using static WebApiEf.Application.CreateBook.BookOperations.CreateBook.CreateBookCommand;
using static WebApiEf.Application.Queries.BookOperations.GetBookQuery;
using static WebApiEf.Application.Queries.BookOperations.GetBooks.GetBookByIdQuery;
using static WebApiEf.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApiEf.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookByIdViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)); //.ForMember(dest => dest.PublishDate,opt => opt.MapFrom(src => src.PublishDate.ToString("dd/mm/yyyy")));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenresDetailViewModel>();
            CreateMap<Author, AuthorViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<CreateUserModel, User>();
        }
    }
}