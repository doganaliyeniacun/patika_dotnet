using AutoMapper;
using WebApiEf.DbOperations;
using WebApiEf.Entities;

namespace WebApiEf.Application.AuthorOperations.Command.Create
{
    public class CreateAuthor
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorModel model;

        public CreateAuthor(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            Author author = _context.Author.SingleOrDefault(x=> x.Name == model.Name.Trim() && x.SurName == model.SurName.Trim());
            if(author is not null)
                throw new InvalidOperationException("Yazar zaten mevcut.");

            author = _mapper.Map<Author>(model);

            _context.Add(author);
            _context.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDay { get; set; }        
    }
}