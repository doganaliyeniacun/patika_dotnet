using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using WebApiEf.Application.AuthorOperations.Queries.GetDetail;
using WebApiEf.DbOperations;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.AuthorOperations.Queries
{
    public class GetAuthorDetailTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenNotAlreadyExistAuthorIdIsGiven_InvalidOperationException_ShouldBeReturnError()
        {
            // Given
            GetAuthorDetail query = new GetAuthorDetail(_context,_mapper);
            query.Id = 0;
        
            // When - Then
            FluentActions
                .Invoking(()=> query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");

        }

        [Fact]
        public void WhenAlreadyExistAuthorIdIsGiven_GetDetail_ShouldBeReturnDetail()
        {
            // Given
            GetAuthorDetail query = new GetAuthorDetail(_context,_mapper);
            query.Id = 1;
        
            // When 
            FluentActions.Invoking(()=> query.Handle()).Invoke();                
            var author = _context.Author.SingleOrDefault(x => x.Id == query.Id);

            //Then
            author.Should().NotBeNull();
        }
    }
}