using FluentValidation;

namespace WebApi.App.ProductOperations.Commands.Update
{
    public class  UpdateProductValidator : AbstractValidator<UpdateProduct>
    {
        public UpdateProductValidator()
        {
            RuleFor(r => r.model.ProductName).NotEmpty().NotNull();
            RuleFor(r => r.model.GenreId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(r => r.model.Price).NotEmpty().NotNull();    
        }
    }
}