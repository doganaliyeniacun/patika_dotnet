using AutoMapper;
using WebApi.App.CustomerOperations.Queries.Get;
using WebApi.Entites;

namespace WebApi.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>()
                .ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(m => m.ShoppingCart.Select(s => s.Product.ProductName)));
        }
    }
}