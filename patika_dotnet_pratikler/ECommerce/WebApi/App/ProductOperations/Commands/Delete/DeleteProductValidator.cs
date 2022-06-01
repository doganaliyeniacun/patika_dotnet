using AutoMapper;
using FluentValidation;

namespace WebApi.App.ProductOperations.Commands.Delete
{
    public class DeleteProductValidator : AbstractValidator<DeleteProduct>
    {
        public DeleteProductValidator()
        {
            RuleFor(r => r.Id).NotEmpty().NotNull().GreaterThan(0);        
        }
    }
}