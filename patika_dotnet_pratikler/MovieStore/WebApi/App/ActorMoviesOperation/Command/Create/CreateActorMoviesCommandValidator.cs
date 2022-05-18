using FluentValidation;

namespace WebApi.App.ActorMoviesOperation.Command.Create
{
    public class CreateActorMoviesCommandValidator : AbstractValidator<CreateActorMoviesCommand>
    {
        public CreateActorMoviesCommandValidator()
        {
            RuleFor(command=> command.CreateActorMovieModel.ActorId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.CreateActorMovieModel.MovieId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}