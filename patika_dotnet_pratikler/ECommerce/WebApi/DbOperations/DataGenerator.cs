using Microsoft.EntityFrameworkCore;
using WebApi.Entites;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ECommerceDbContext(serviceProvider.GetRequiredService<DbContextOptions<ECommerceDbContext>>()))
            { 
                context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Customer1",
                        SurName = "CustomerSurname1",    
                        Email = "ad1@ad.com",
                        Password = "1"                    
                    },
                    new Customer
                    {
                        Name = "Customer2",
                        SurName = "CustomerSurname2",  
                        Email = "ad2@ad.com",
                        Password = "2"                           
                    },
                    new Customer
                    {
                        Name = "Customer3",
                        SurName = "CustomerSurname3",
                        Email = "ad3@ad.com",
                        Password = "3"                             
                    },
                    new Customer
                    {
                        Name = "Customer4",
                        SurName = "CustomerSurname4",
                        Email = "ad4@ad.com",
                        Password = "4"                             
                    },
                    new Customer() 
                    { 
                        Name = "testName", 
                        SurName = "testSurname" , 
                        Email = "test@gmail.com", 
                        Password = "test"
                    }
                );

                context.Products.AddRange(
                    new Product()
                    {
                        ProductName = "Mousepad",
                        GenreId = 1,
                        Price = 100
                    },
                    new Product()
                    {
                        ProductName = "Keyboard",
                        GenreId = 1,
                        Price = 250
                    },
                    new Product()
                    {
                        ProductName = "T-Shirt",
                        GenreId = 3,
                        Price = 80
                    },
                    new Product()
                    {
                        ProductName = "Pant",
                        GenreId = 3,
                        Price = 190
                    }
                );

                context.ShoppingCarts.AddRange
                (
                    new ShoppingCart()
                    {
                        PurchasedDate = new DateTime(2022,01,05),
                        CustomerId = 1,
                        ProductId = 1,
                    },
                    new ShoppingCart()
                    {   
                        PurchasedDate = new DateTime(2022,01,04),                     
                        CustomerId = 1,
                        ProductId = 2,
                    },
                    new ShoppingCart()
                    {
                        PurchasedDate = new DateTime(2022,02,05),
                        CustomerId = 2,
                        ProductId = 3,
                    },
                    new ShoppingCart()
                    {
                        PurchasedDate = new DateTime(2022,05,01),
                        CustomerId = 3,
                        ProductId = 1,
                    },
                    new ShoppingCart()
                    {
                        PurchasedDate = new DateTime(2022,08,28),
                        CustomerId = 3,
                        ProductId = 4,
                    },
                    new ShoppingCart()
                    {
                        PurchasedDate = new DateTime(2022,01,05),
                        CustomerId = 4,
                        ProductId = 2,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}