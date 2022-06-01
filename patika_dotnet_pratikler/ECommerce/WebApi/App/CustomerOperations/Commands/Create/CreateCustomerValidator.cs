using AutoMapper;
using FluentValidation;

namespace WebApi.App.CustomerOperations.Commands.Create
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomer>
    {
        public CreateCustomerValidator()
        {
            RuleFor(r => r.model.Name).NotEmpty().NotNull();
            RuleFor(r => r.model.SurName).NotEmpty().NotNull();
            RuleFor(r => r.model.Password).NotEmpty().NotNull();
            RuleFor(r => r.model.Email).NotEmpty().NotNull().EmailAddress();
        }
    }
}