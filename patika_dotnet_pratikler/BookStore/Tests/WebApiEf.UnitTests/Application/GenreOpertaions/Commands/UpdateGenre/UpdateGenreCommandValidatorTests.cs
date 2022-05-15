using FluentAssertions;
using WebApiEf.Application.GenreOperations.Commands.UpdateGenre;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.GenreOpertaions.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("tes")]
        [InlineData(" ")]
        [InlineData("string")]
        public void WhenGenreTitleIsGiven_validator_ShouldBeReturnError(string name)
        {
            // Given
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = new UpdateGenreModel()
            {
                Name = name
            };
        
            // When
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenValidGenreTitleAreGiven_Validator_ShouldBeValid()
        {
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Model = new UpdateGenreModel()
            {
                Name = "test"
            };
        
            // When
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            var result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}