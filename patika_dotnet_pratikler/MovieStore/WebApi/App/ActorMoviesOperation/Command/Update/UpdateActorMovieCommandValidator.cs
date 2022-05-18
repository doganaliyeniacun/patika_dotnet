using FluentValidation;

namespace WebApi.App.ActorMoviesOperation.Command.Update
{
    public class UpdateActorMovieCommandValidator : AbstractValidator<UpdateActorMovieCommand>
    {
        public UpdateActorMovieCommandValidator()
        {
            RuleFor(command=> command.UpdateActorMovieModel.ActorId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.UpdateActorMovieModel.MovieId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command=> command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}