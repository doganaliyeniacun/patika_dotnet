using FluentValidation;

namespace WebApi.App.CustomerOperations.Queries.GetDetail
{
    public class GetCustomerDetailValidator : AbstractValidator<GetCustomersDetail>
    {
        public GetCustomerDetailValidator()
        {
            RuleFor(r => r.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}