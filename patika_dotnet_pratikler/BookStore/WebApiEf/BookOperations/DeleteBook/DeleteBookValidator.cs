using FluentValidation;

namespace WebApiEf.BookOperations.DeleteBook
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}