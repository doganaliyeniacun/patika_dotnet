using FluentValidation;

namespace WebApiEf.Application.GenreOperations.Commands.CreateCommand
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).NotEqual("string");
        }
    }
}