using FluentAssertions;
using WebApiEf.Application.GenreOperations.Commands.CreateCommand;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.GenreOpertaions.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void WhenGenreTitleAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Given
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel ()
            {
                Name = "tes"
            };
        
            // When
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenGenreTitleAreGiven_validator_ShouldBeValid()
        {
            // Given
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel ()
            {
                Name = "test"
            };
        
            // When
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}