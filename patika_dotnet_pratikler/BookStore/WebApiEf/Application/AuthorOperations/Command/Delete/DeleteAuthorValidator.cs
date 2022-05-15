using FluentValidation;

namespace WebApiEf.Application.AuthorOperations.Command.Delete
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}