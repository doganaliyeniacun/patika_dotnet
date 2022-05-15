using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using WebApiEf.Application.GenreOperations.Commands.CreateCommand;
using WebApiEf.DbOperations;
using WebApiEf.Entities;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.GenreOpertaions.Commands.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExistGenreTitleIsGiven_InvalidaOperationException_ShouldBeReturnError()
        {
            // Given
            Genre genre = new Genre() 
            {
                Name = "test"
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();


            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = new CreateGenreModel()
            {
                Name = genre.Name
            };

            // When - Then
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputAreGiven_CreateGenre_ShouldBeCreate()
        {
            // Given
            CreateGenreCommand command = new CreateGenreCommand(_context);
            CreateGenreModel model = new CreateGenreModel()
            {
                Name = "test2"
            };

            command.Model = model;
            
        
            // When
            FluentActions.Invoking(()=> command.Handle()).Invoke();
        
            // Then
            var genre = _context.Genres.SingleOrDefault(x => x.Name == model.Name);

            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);

        }
    }
}