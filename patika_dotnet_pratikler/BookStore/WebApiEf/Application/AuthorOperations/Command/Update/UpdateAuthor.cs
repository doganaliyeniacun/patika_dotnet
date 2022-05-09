using AutoMapper;
using WebApiEf.DbOperations;
using WebApiEf.Entities;

namespace WebApiEf.Application.AuthorOperations.Command.Update
{
    public class UpdateAuthor
    {
        public UpdateAuthorModel model;
        public int Id { get; set; }
        private readonly BookStoreDbContext _context;


        public UpdateAuthor(BookStoreDbContext context)
        {
            _context = context;

        }

        public void Handle()
        {
            Author author = _context.Author.SingleOrDefault(x => x.Id == Id);
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı.");

            author.Name = string.IsNullOrEmpty(model.Name) ? author.Name : model.Name.Trim();
            author.SurName = string.IsNullOrEmpty(model.SurName) ? author.SurName : model.SurName.Trim();
            author.Birthday = model.BirthDay == default ? author.Birthday : model.BirthDay;

            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}