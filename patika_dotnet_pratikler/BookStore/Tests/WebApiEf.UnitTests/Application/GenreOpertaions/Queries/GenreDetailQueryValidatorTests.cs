using FluentAssertions;
using WebApiEf.Application.GenreOperations.Queries.GetGenresDetail;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.GenreOpertaions.Queries
{
    public class GenreDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        public void WhenGenreDetailIdIsGiven_validator_ShouldBeReturnError(int genreId)
        {
            // Given
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId = genreId;
        
            // When
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result  = validator.Validate(query);
        
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void WhenGenreDetailIdIsGiven_validator_ShouldBeValid(int genreId)
        {
            // Given
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId = genreId;
        
            // When
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            var result  = validator.Validate(query);
        
            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}