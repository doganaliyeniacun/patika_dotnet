using FluentValidation;

namespace WebApi.App.ShoppingCartOperations.Commands.Delete
{
    public class DeleteShoppingCartValidator : AbstractValidator<DeleteShoppingCart>
    {
        public DeleteShoppingCartValidator()
        {
            RuleFor(r => r.Id).NotEmpty().NotNull().GreaterThan(0);     
        }
    }
}