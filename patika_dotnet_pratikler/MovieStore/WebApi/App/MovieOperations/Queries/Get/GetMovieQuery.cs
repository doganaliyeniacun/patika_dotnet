using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi.DbOperations;
using WebApi.Entites;

namespace WebApi.App.MovieOperations.Queries.Get
{
    public class GetMovieQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MovieQueryViewModel> Handle()
        {
            var movies = _context.Movies.Include(i => i.ActorMovies).ThenInclude(t=> t.Actor).OrderBy(x=> x.Id).ToList();                    
            List<MovieQueryViewModel> vm = _mapper.Map<List<MovieQueryViewModel>>(movies);
            
            return vm;
        }
    }

    public class MovieQueryViewModel
    {
        public string Name { get; set; }
        public string PublishDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public IReadOnlyList<string> Actors { get; set; }
        public int Price { get; set; }
    }
}