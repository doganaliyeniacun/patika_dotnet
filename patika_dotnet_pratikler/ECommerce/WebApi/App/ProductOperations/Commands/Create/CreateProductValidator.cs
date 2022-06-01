using AutoMapper;
using FluentValidation;

namespace WebApi.App.ProductOperations.Commands.Create
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(r => r.model.ProductName).NotEmpty().NotNull();
            RuleFor(r => r.model.GenreId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(r => r.model.Price).NotEmpty().NotNull();            
        }
    }
}