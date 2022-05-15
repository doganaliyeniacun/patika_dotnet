using System.Reflection.PortableExecutable;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiEf.Common;
using WebApiEf.DbOperations;
using WebApiEf.Entities;

namespace WebApiEf.Application.Queries.BookOperations
{
    public class GetBookQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x => x.Genre).Include(x=> x.Author).OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
                        
            return vm;
        }

        public class BooksViewModel
        {
            public string Title { get;set;}
            public int PageCount { get;set;}
            public string PublishDate { get;set;}
            public string Genre { get;set;}
            public string AuthorName { get;set;}
            public string AuthorSurName { get;set;}
        }
    }
}