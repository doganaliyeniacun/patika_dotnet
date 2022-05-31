using Microsoft.EntityFrameworkCore;
using WebApi.Entites;

namespace WebApi.DbOperations
{
    public class ECommerceDbContext : DbContext, IECommerceDbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}