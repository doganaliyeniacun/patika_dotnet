using FluentValidation;

namespace WebApi.App.ShoppingCartOperations.Commands.Create
{
    public class CreateShoppingCartValidator : AbstractValidator<CreateShoppingCart>
    {
        public CreateShoppingCartValidator()
        {
            RuleFor(r => r.model.CustomerId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(r => r.model.ProductId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}