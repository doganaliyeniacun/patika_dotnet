using System;
using System.Linq;
using FluentAssertions;
using WebApiEf.Application.CreateBook.BookOperations.DeleteBook;
using WebApiEf.Application.CreateBook.BookOperations.UpdateBook;
using WebApiEf.DbOperations;
using WebApiEf.Entities;
using WebApiEf.UnitTests.TestSetup;
using Xunit;
using static WebApiEf.Application.CreateBook.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApiEf.UnitTests.Application.BookOpertaions.Commands.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotExistBookIdIsGiven_Update_ShouldBeReturnErorrs()
        {
            // Given
            UpdateBookCommand command = new UpdateBookCommand(_context);
            int id = 0;
            
            // When - Then
            FluentActions
            .Invoking(()=> command.Handle(id))
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");            
        }

        [Fact]
        public void WhenUpdatedBookModelIsGiven_Update_ShouldBeUpdated()
        {
            // Given
            UpdateBookCommand command = new UpdateBookCommand(_context);
            int id = 1;
            command.Model = new UpdateBookModel ()
            {
                Title = "Test",
                AuthorId = 2,
                GenreId = 2,
                PageCount = 2000,
                PublishDate = DateTime.Now.Date.AddYears(-1)
            };
            
            FluentActions.Invoking(()=> command.Handle(id)).Invoke();

            // When 
            Book book = _context.Books.SingleOrDefault(x => x.Id == id);
            
                     
            //Then
            book.Should().NotBeNull();
            book.Title.Should().Be(command.Model.Title);
            book.AuthorId.Should().Be(command.Model.AuthorId);
            book.GenreId.Should().Be(command.Model.GenreId);
            book.PageCount.Should().Be(command.Model.PageCount);
            book.PublishDate.Should().Be(command.Model.PublishDate);
        }
    }
}