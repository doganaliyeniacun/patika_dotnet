using FluentValidation;

namespace WebApiEf.Application.AuthorOperations.Command.Delete
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthor>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}