using FluentValidation;

namespace WebApi.App.ProductOperations.Queries.GetDetail
{
    public class GetProductDetailValidator : AbstractValidator<GetProductDetail>
    {
        public GetProductDetailValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}