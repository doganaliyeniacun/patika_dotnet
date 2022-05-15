using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using WebApiEf.Application.AuthorOperations.Command.Delete;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        public void WhenAuthorIdIsGiven_Validator_ShouldBeReturnError(int id)
        {
            // Given
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.Id = id;
        
            // When
            DeleteAuthorValidator validator = new DeleteAuthorValidator();
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
        public void WhenAuthorIdIsGiven_Validator_ShouldBeValid(int id)
        {
            // Given
            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.Id = id;
        
            // When
            DeleteAuthorValidator validator = new DeleteAuthorValidator();
            var result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);

        }
    }
}