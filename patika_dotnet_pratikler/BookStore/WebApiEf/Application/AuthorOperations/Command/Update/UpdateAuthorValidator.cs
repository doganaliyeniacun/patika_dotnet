using FluentValidation;

namespace WebApiEf.Application.AuthorOperations.Command.Update
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(command => command.model.Name).MinimumLength(4).When(x=> x.model.Name.Trim() != string.Empty);
            RuleFor(command => command.model.SurName).MinimumLength(4).When(x=> x.model.Name.Trim() != string.Empty);
            RuleFor(command => command.model.BirthDay).LessThan(DateTime.Now.Date);
        }
    }
}