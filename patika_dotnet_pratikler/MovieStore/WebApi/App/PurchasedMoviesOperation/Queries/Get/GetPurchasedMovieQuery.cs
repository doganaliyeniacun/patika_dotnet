using System.ComponentModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.PurchasedMoviesOperation.Queries.Get
{
    public class GetPurchasedMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPurchasedMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<PurchasedMoviesViewModel> Handle()
        {
            List<Customer> list = _dbContext.Customers.Include(i => i.PurchasedMovies).ThenInclude(t => t.Movie).OrderBy(x => x.Id).ToList();
            List<PurchasedMoviesViewModel> vm = _mapper.Map<List<PurchasedMoviesViewModel>>(list);

            return vm;
        }
    }

    public class PurchasedMoviesViewModel
    {
        public string NameSurname { get; set; }
        public IReadOnlyList<string> Movies { get; set; }
    }
}