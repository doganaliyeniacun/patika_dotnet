using FluentValidation;
using WebApiEf.Application.Queries.BookOperations.GetBooks;

namespace WebApiEf.Application.Queries.BookOperations.GetBookById
{
    public class GetBookByIdValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}