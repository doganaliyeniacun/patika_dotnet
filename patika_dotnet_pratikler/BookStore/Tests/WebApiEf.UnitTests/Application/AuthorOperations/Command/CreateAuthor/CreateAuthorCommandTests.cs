using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using WebApiEf.Application.AuthorOperations.Command.Create;
using WebApiEf.DbOperations;
using WebApiEf.Entities;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.AuthorOperations.Command.CreateAuthor
{
    
    public class CreateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;            
        }

        [Fact]
        public void WhereAlreadyExistAuthorTitleIsGiven_InvalidOperationsExcepiton_ShouldBeReturnErorr()
        {
            // Given

            var author = new Author()
            {
                Name = "Test",
                SurName = "Test",
                Birthday = new DateTime(1997,01,07)
            };
            _context.Author.Add(author);
            _context.SaveChanges();
            
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            command.model = new CreateAuthorModel()
            {
                Name = author.Name,
                SurName = author.SurName
            };

        
            // When - Then
            FluentActions
                .Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Yazar zaten mevcut.");
            
        }

        [Fact]
        public void WhenCreateAuthorIsGiven_CreateAuthor_ShouldBeCreate()
        {
            // Given
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            command.model = new CreateAuthorModel()
            {
                Name = "Test2",
                SurName = "Test2",
                BirthDay = new DateTime(1997,01,07)
            };
        
            // When
            FluentActions.Invoking(()=> command.Handle()).Invoke();
            var author = _context.Author.SingleOrDefault(x=> x.Name == command.model.Name);

            // Then
            author.Should().NotBeNull();
        }
    }
}