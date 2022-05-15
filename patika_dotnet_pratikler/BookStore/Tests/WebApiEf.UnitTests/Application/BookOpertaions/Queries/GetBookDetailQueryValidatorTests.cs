using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using WebApiEf.Application.Queries.BookOperations.GetBookById;
using WebApiEf.Application.Queries.BookOperations.GetBooks;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.BookOpertaions.Queries
{
    public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void WhenBookIdIsGiven_Validator_ShouldBeReturnErrors(int id)
        {
            // Given
            GetBookByIdQuery query = new GetBookByIdQuery(null,null);
            query.Id = id;
        
            // When
            GetBookByIdValidator validator = new GetBookByIdValidator();
            var result = validator.Validate(query);
        
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void WhenBookIdIsGiven_Validator_ShouldBeNotReturnError(int id)
        {
            // Given
            GetBookByIdQuery query = new GetBookByIdQuery(null,null);
            query.Id = id;
        
            // When
            GetBookByIdValidator validator = new GetBookByIdValidator();
            var result = validator.Validate(query);
        
            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}