using FluentValidation;

namespace WebApi.App.ShoppingCartOperations.Queries.GetDetail
{
    public class GetShoppingCartDetailValidator : AbstractValidator<GetShoppingCartDetail>
    {
        public GetShoppingCartDetailValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}