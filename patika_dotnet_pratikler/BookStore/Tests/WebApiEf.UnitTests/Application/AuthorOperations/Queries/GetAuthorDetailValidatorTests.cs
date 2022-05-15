using FluentAssertions;
using WebApiEf.Application.AuthorOperations.Queries.GetDetail;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.AuthorOperations.Queries
{
    public class GetAuthorDetailValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void WhenInvalidInputIsGiven_validator_ShouldBeReturnError(int id)
        {
            // Given
            GetAuthorDetail query = new GetAuthorDetail(null,null);
            query.Id = id;
        
            // When
            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            var result = validator.Validate(query);
        
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void WhenValidInputIsGiven_validator_ShouldBeValid(int id)
        {
            // Given
            GetAuthorDetail query = new GetAuthorDetail(null,null);
            query.Id = id;
        
            // When
            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            var result = validator.Validate(query);
        
            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}