using System.ComponentModel.DataAnnotations;

namespace WebApi.Entites
{
    public class Customer
    {
        [Key]
        public int  Id { get; set; }
        public string Name { get; set; }
        public string  SurName { get; set; }
    }
}