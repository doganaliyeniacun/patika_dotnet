using System.ComponentModel.DataAnnotations;

namespace WebApi.Entites
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }        
        public  List<Actor> Actors { get; set; }                
        public int Price { get; set; }

    }
}