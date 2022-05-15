using System.Linq;
using FluentAssertions;
using WebApiEf.Application.CreateBook.BookOperations.DeleteBook;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.BookOpertaions.Commands.DeleteBook
{
    public class DeleteBookValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-4)]
        [InlineData(-5)]
        [InlineData(-6)]
        [InlineData(-7)]
        [InlineData(-8)]
        [InlineData(-9)]
        [InlineData(-10)]
        public void WhenDeleteIdIsGiven_Validator_ShouldBeReturnErrors(int bookId)
        {
            // Given
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;

            // When
            DeleteBookValidator validator = new DeleteBookValidator();
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
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void WhenDeleteIdIsGiven_Validator_ShouldNotBeReturnErrors(int bookId)
        {
            // Given
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;

            // When
            DeleteBookValidator validator = new DeleteBookValidator();
            var result = validator.Validate(command);

            // Then
            result.Errors.Count.Should().BeLessThanOrEqualTo(0);
        }
    }
}





