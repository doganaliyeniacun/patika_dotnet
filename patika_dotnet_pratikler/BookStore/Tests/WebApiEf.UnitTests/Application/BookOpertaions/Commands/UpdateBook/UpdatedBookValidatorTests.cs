using System;
using FluentAssertions;
using WebApiEf.Application.CreateBook.BookOperations.UpdateBook;
using WebApiEf.UnitTests.TestSetup;
using Xunit;
using static WebApiEf.Application.CreateBook.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApiEf.UnitTests.Application.BookOpertaions.Commands.UpdateBook
{
    public class UpdatedBookValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Tes",1,1,1)]
        [InlineData("string",1,1,1)]
        [InlineData("Testt",0,1,1)]
        [InlineData("Testt",1,0,1)]
        [InlineData("Testt",1,1,0)]
        public void WhenUpdatedBookIsGiven_Update_ShouldBeReturnErrors(string title, int authorId, int genreId, int pageCount)
        {
            // Given
            UpdateBookCommand command = new UpdateBookCommand(null); 
            command.Model = new UpdateBookModel()
            {
                Title = title,
                AuthorId = authorId,
                GenreId = genreId,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
            };           
        
            // When
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var  result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenUpdatedBookDateIsGiven_Update_ShouldBeReturnErrors()
        {
            // Given
            UpdateBookCommand command = new UpdateBookCommand(null); 
            command.Model = new UpdateBookModel()
            {
                Title = "Testt",
                AuthorId = 1,
                GenreId = 1,
                PageCount = 1,
                PublishDate = DateTime.Now.Date,
            };           
        
            // When
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var  result = validator.Validate(command);
        
            // Then
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}