using System;
using System.Linq;
using FluentAssertions;
using WebApiEf.Application.GenreOperations.Commands.UpdateGenre;
using WebApiEf.DbOperations;
using WebApiEf.Entities;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.GenreOpertaions.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistGenreId_InvalidExceptionOperations_ShouldBeReturnError()
        {
            // Given            
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 0;

            // When - Then
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek kitap bulunamadı.");
        }

        [Fact]
        public void WhenUpdatedGenreAreGiven_GenreUpdate_ShouldBeUpratedGenre()
        {
            // Given
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 1;
            command.Model = new UpdateGenreModel()
            {
                Name = "test"
            };
        
            FluentActions.Invoking(()=> command.Handle()).Invoke();

            // When
            Genre genre = _context.Genres.SingleOrDefault(x=> x.Id == command.GenreId);
        
            // Then
            genre.Should().NotBeNull();
            genre.Name.Should().Be(command.Model.Name);
        }

       
    }
}