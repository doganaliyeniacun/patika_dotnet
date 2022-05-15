using System;
using FluentAssertions;
using WebApiEf.Application.AuthorOperations.Command.Update;
using WebApiEf.Application.CreateBook.BookOperations.UpdateBook;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("tes","test")]
        [InlineData("test","tes")]
        public void WhenInvalidInputIsGiven_validator_ShouldBeReturnErorr(string surName, string name)
        {
            // Given
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.model = new UpdateAuthorModel()
            {
                Name = name,
                SurName = surName,
                BirthDay = new DateTime(1997,01,07)
            };
        
            // When
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Theory]
        [InlineData("test","test")]
        public void WhenValidInputIsGiven_validator_ShouldBeValid(string surName, string name)
        {
            // Given
            UpdateAuthorCommand command = new UpdateAuthorCommand(null);
            command.model = new UpdateAuthorModel()
            {
                Name = name,
                SurName = surName,
                BirthDay = new DateTime(1997,01,07)
            };
        
            // When
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            var result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}