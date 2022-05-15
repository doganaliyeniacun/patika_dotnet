using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using WebApiEf.Application.CreateBook.BookOperations.DeleteBook;
using WebApiEf.DbOperations;
using WebApiEf.Entities;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.BookOpertaions.Commands.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenDeleteBookIdIsGiven_InvalidOperationException_ShouldBeReturnErrors()
        {            
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = 100;

            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap bulunamadı!");
        }

        [Fact]
        public void WhenDeleteBookIdIsGiven_DeleteBook_ShouldBeReturnNull()
        {            
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = 1;

            FluentActions.Invoking(()=> command.Handle()).Invoke();
            var book = _context.Books.SingleOrDefault(book => book.Id == command.BookId); 

            book.Should().BeNull();                
        }

    }
}