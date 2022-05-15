using System;
using AutoMapper;
using FluentAssertions;
using WebApiEf.Application.Queries.BookOperations.GetBooks;
using WebApiEf.DbOperations;
using WebApiEf.UnitTests.TestSetup;
using Xunit;

namespace WebApiEf.UnitTests.Application.BookOpertaions.Queries
{
    public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenBookIdIsGiven_BookDetail_ShouldBeReturnError()
        {
            //given
            GetBookByIdQuery query = new GetBookByIdQuery(_context, _mapper);
            query.Id = 0;

            //when - then
            FluentActions
                .Invoking(()=> query.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı.");            
        }
    }
}