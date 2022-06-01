using AutoMapper;
using FluentValidation;

namespace WebApi.App.CustomerOperations.Commands.Delete
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomer>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(r => r.Id).NotEmpty().NotNull().GreaterThan(0);        
        }
    }
}