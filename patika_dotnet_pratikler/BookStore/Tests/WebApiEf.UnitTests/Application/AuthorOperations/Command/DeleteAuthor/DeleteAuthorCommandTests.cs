using System;
using FluentAssertions;
using WebApiEf.Application.AuthorOperations.Command.Delete;
using WebApiEf.DbOperations;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenDeleteAuthorIdIsGiven_InvalidOperationsException_ShouldBeReturnError()
        {
            // Given
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.Id = 0;
        
            // When - Then
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı.");
        
        }

        [Fact]
        public void WhenAlreadyExistBookAuthorIdIsGiven_InvalidOperationsException_ShouldBeReturnError()
        {
            // Given
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.Id = 1;
        
            // When - Then
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazarın kitabı yayında önce yayında olan kitabı siliniz.");
        
        }
    }
}