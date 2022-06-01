using AutoMapper;
using WebApi.App.CustomerOperations.Commands.Create;
using WebApi.App.CustomerOperations.Queries.Get;
using WebApi.App.ProductOperations.Commands.Create;
using WebApi.App.ProductOperations.Queries.Get;
using WebApi.App.ShoppingCartOperations.Commands.Create;
using WebApi.App.ShoppingCartOperations.Queries.Get;
using WebApi.Common.Enums;
using WebApi.Entites;

namespace WebApi.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //customer
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(m => m.ShoppingCart.Select(s => s.Product.ProductName)));
            CreateMap<CustomerModel, Customer>();

            //product             
            CreateMap<ProductModel, Product>();    
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(m=> (ProductGenreEnums)m.GenreId)); 

            //shoppingcart
            CreateMap<ShoppingCartModel, ShoppingCart>()
                .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => DateTime.Now.Date));
            CreateMap<Customer, ShoppingCartViewModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(m => m.Name + " " + m.SurName))
                .ForMember(dest=> dest.Products, opt => opt.MapFrom(m=>m.ShoppingCart.Select(s => s.Product.ProductName)));
                    
        }
    }
}