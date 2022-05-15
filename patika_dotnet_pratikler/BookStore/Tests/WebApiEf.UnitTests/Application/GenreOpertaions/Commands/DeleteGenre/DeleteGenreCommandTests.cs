using System;
using System.Linq;
using FluentAssertions;
using WebApiEf.Application.GenreOperations.Commands.DeleteGenre;
using WebApiEf.DbOperations;
using WebApiEf.Entities;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.GenreOpertaions.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenDeleteGenreIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            // Given
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = 0;
        
            // When - Then
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek kitap türü bulunamadı.");
        
        }

        [Fact]
        public void WhenDeleteGenreIdIsGiven_DeleteGenre_ShouldBeDelete()
        {
            // Given
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = 1;
        
            // When
            FluentActions.Invoking(()=> command.Handle()).Invoke();
            Genre genre = _context.Genres.SingleOrDefault(x=> x.Id == command.GenreId);
        
            // Then
            genre.Should().BeNull();
        }
    }
}