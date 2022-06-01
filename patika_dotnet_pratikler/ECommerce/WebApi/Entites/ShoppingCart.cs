using System.ComponentModel.DataAnnotations;

namespace WebApi.Entites
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int CustomerId { get; set; }            
        public Customer Customer { get; set; }            
        public int ProductId { get; set; }            
        public Product Product { get; set; }            
    }
}