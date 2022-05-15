using FluentValidation;

namespace WebApiEf.Application.AuthorOperations.Command.Create
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(command => command.model.Name).NotEmpty();
            RuleFor(command => command.model.SurName).NotEmpty();
            RuleFor(command => command.model.BirthDay).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}