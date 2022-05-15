using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiEf.Common;
using WebApiEf.DbOperations;
using WebApiEf.Entities;

namespace WebApiEf.Application.Queries.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public int Id { get; set; }



        public GetBookByIdQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetBookByIdViewModel Handle()
        {
            Book book = _context.Books.Include(x => x.Genre).Include(x=> x.Author).SingleOrDefault(x => x.Id == Id);

            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            GetBookByIdViewModel vm = _mapper.Map<GetBookByIdViewModel>(book);

            return vm;
        }

        public class GetBookByIdViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string Genre { get; set; }
            public string PublishDate { get; set; }
            public string AuthorName { get; set; }
            public string AuthorSurName { get; set; }
        }
    }
}