using FluentAssertions;
using WebApiEf.Application.GenreOperations.Commands.CreateCommand;
using WebApiEf.Application.GenreOperations.Commands.DeleteGenre;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.GenreOpertaions.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        public void WhenDeleteGenreIdIsGiven_validator_ShouldBeReturnError(int genreId)
        {
            // Given
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = genreId;
        
            // When
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void WhenDeleteGenreIdIsGiven_validator_ShouldBeValid(int genreId)
        {
            // Given
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = genreId;
        
            // When
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}