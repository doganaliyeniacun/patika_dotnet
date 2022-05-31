using Microsoft.EntityFrameworkCore;
using WebApi.Entites;

namespace WebApi.DbOperations
{
    public interface IECommerceDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ShoppingCart> ShoppingCarts { get; set; }


        int SaveChanges();
    }
}