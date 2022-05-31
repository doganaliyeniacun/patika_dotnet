using System.ComponentModel.DataAnnotations;

namespace WebApi.Entites
{
    public class Product
    {
        [Key]
        public int Id { get; set; }    
        public string ProductName { get; set; }
        public int GenreId { get; set; }
        public int Price { get; set; }                
    }
}