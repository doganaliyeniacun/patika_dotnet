using FluentValidation;

namespace WebApi.App.ShoppingCartOperations.Commands.Update
{
    public class  UpdateShoppingCartValidator : AbstractValidator<UpdateShoppingCart>
    {
        public UpdateShoppingCartValidator()
        {
            RuleFor(r => r.model.CustomerId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(r => r.model.ProductId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}