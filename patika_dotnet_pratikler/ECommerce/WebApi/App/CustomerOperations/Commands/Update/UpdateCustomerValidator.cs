using FluentValidation;

namespace WebApi.App.CustomerOperations.Commands.Update
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomer>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(r => r.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(r => r.model.Name).NotEmpty().NotNull();
            RuleFor(r => r.model.SurName).NotEmpty().NotNull();
            RuleFor(r => r.model.Password).NotEmpty().NotNull();
            RuleFor(r => r.model.Email).NotEmpty().NotNull().EmailAddress();
        }
    }
}