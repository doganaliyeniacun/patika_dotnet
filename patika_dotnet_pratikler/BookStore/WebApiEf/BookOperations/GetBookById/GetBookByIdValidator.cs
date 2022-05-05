using FluentValidation;
using WebApiEf.BookOperations.GetBooks;

namespace WebApiEf.BookOperations.GetBookById
{
    public class GetBookByIdValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}