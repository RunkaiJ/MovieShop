using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository repository) : base(repository)
        {
            _movieRepository = repository;
        }

        public IEnumerable<Movie> GetPagedByGenre(int page, int pageSize, int selectedGenreId)
        {
            return _movieRepository.GetPagedByGenre(page, pageSize, selectedGenreId);   
        }
        public IEnumerable<Movie> GetPaged(int page, int pageSize)
        {
            return _movieRepository.GetPaged(page, pageSize);
        }
    }
}
