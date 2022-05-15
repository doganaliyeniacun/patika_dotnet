using System;
using System.Linq;
using FluentAssertions;
using WebApiEf.Application.AuthorOperations.Command.Update;
using WebApiEf.DbOperations;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenNotAlreadyExistUpdateAuthorIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            // Given
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Id = 0;
        
            // When - Then
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar bulunamadı.");
        }

        [Fact]
        public void WhenUpdateAtuhorIsGiven_UpdateAuthor_ShouldBeUpdate()
        {
            // Given
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Id = 1;
            command.model = new UpdateAuthorModel()
            {
                Name = "test",
                SurName = "test",
                BirthDay = new DateTime(1997,01,07)
            };
        
            // When
            FluentActions.Invoking(()=> command.Handle()).Invoke();
            var author = _context.Author.SingleOrDefault(x => x.Name == command.model.Name);

            // Then
            author.Should().NotBeNull();
        }
    }
}