using FluentValidation;

namespace WebApi.App.PurchasedMoviesOperation.Commands.Delete
{
    public class DeleteDirectorMovieCommandValidator : AbstractValidator<DeleteDirectorMovieCommand>
    {
        public DeleteDirectorMovieCommandValidator()
        {            
            RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}