using System;
using FluentAssertions;
using WebApiEf.Application.CreateBook.BookOperations.CreateBook;
using WebApiEf.UnitTests.TestSetup;
using Xunit;
using static WebApiEf.Application.CreateBook.BookOperations.CreateBook.CreateBookCommand;

namespace WebApiEf.UnitTests.Application.BookOpertaions.Commands.CreateBook
{
   public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord OF The Rings",0,0,0)]
        [InlineData("Lord OF The Rings",0,1,1)]
        [InlineData("Lord OF The Rings",100,0,1)]
        [InlineData("",0,0,0)]
        [InlineData("",100,1,1)]
        [InlineData("",0,1,0)]
        [InlineData("Lor",100,1,1)]
        [InlineData("Lord",100,0,1)]
        [InlineData("Lord",0,1,0)]
        [InlineData(" ",100,1,0)]        
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId, int authorId)
        {
             //arrange
             CreateBookCommand command = new CreateBookCommand(null,null);
             command.Model = new CreateBookModel()
             {
                 Title = title,
                 PageCount = pageCount,
                 PublishDate = DateTime.Now.Date.AddYears(-1),
                 GenreId = genreId,
                 AuthorId = authorId
             };

             //act
             CreateBookCommandValidator validator = new CreateBookCommandValidator();
             var result = validator.Validate(command);

             //assert 
             result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]        
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
        {
            //arrange
             CreateBookCommand command = new CreateBookCommand(null,null);
             command.Model = new CreateBookModel()
             {
                 Title = "Zengin Baba Fakir Baba",
                 PageCount = 100,
                 PublishDate = DateTime.Now.Date,
                 GenreId = 1,
                 AuthorId = 1
             };

             //act
             CreateBookCommandValidator validator = new CreateBookCommandValidator();
             var result = validator.Validate(command);

             //assert 
             result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]        
        public void WhenValidInputsIsGiven_Validator_ShouldNotBeReturnError()
        {
            //arrange
             CreateBookCommand command = new CreateBookCommand(null,null);
             command.Model = new CreateBookModel()
             {
                 Title = "Zengin Baba Fakir Baba",
                 PageCount = 100,
                 PublishDate = DateTime.Now.Date.AddYears(-2),
                 GenreId = 1,
                 AuthorId = 1
             };

             //act
             CreateBookCommandValidator validator = new CreateBookCommandValidator();
             var result = validator.Validate(command);

             //assert 
             result.Errors.Count.Should().Be(0);
        }
    }
}