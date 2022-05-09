using FluentValidation;

namespace WebApiEf.Application.AuthorOperations.Queries.GetDetail
{
    public class GetAuthorDetailValidator : AbstractValidator<GetAuthorDetail>
    {
        public GetAuthorDetailValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}