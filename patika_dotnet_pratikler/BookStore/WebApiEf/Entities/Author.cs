using System.ComponentModel.DataAnnotations;

namespace WebApiEf.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }
        public DateTime Birthday { get; set; }

        public Book Book { get; set; }

    }
}