using System;
using FluentAssertions;
using WebApiEf.Application.AuthorOperations.Command.Create;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(" ","test")]
        [InlineData("test"," ")]
        [InlineData(" "," ")]
        public void WhenCreateAuthorIsGiven_validator_ShouldBeReturnErorr(string name, string surName)
        {
            // Given
            CreateAuthorCommand command = new CreateAuthorCommand(null,null);
            command.model = new CreateAuthorModel()
            {
                Name = name,
                SurName = surName,
                BirthDay = new DateTime(1997,01,07)
            };
        
            // When
            CreateAuthorValidator validator = new CreateAuthorValidator();
            var result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("test","test")]        
        public void WhenCreateAuthorIsGiven_validator_ShouldBeValid(string name, string surName)
        {
            // Given
            CreateAuthorCommand command = new CreateAuthorCommand(null,null);
            command.model = new CreateAuthorModel()
            {
                Name = name,
                SurName = surName,
                BirthDay = new DateTime(1997,01,07)
            };
        
            // When
            CreateAuthorValidator validator = new CreateAuthorValidator();
            var result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}