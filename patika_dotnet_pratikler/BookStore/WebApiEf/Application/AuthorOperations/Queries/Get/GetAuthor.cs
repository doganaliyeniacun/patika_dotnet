using System.Collections.Immutable;
using System.ComponentModel;
using AutoMapper;
using WebApiEf.DbOperations;
using WebApiEf.Entities;

namespace WebApiEf.Application.AuthorOperations.Queries.Get
{
    public class GetAuthor
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthor(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var query = _context.Author.OrderBy(x=> x.Id).ToList();
            List<AuthorViewModel> vm = _mapper.Map<List<AuthorViewModel>>(query);

            return vm;
        }
    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string BirthDay { get; set; }
    }
}