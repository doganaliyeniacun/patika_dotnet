using FluentValidation;

namespace WebApi.App.CustomerOperations.Commands.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command=> command.Model.Name).NotNull().NotEmpty();
            RuleFor(command=> command.Model.SurName).NotNull().NotEmpty();
        }
    }
}