using FluentValidation;

namespace WebApiEf.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).NotNull().NotEmpty().NotEqual("string");
        }
    }
}