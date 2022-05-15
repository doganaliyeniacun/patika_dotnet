using System;
using AutoMapper;
using FluentAssertions;
using WebApiEf.Application.GenreOperations.Queries.GetGenresDetail;
using WebApiEf.DbOperations;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.GenreOpertaions.Queries
{
    public class GenreDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGenreDetailIdIsGiven_InvalidOperationException_ShouldBeReturnErorr()
        {
            // Given
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
            query.GenreId = 0;
        
            // When - Then
            FluentActions
                .Invoking(()=> query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap türü bulunamadı.");
        
        }
    }
}