using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.DTOs;
using Azure;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService : IService<Movie>
    {
        public IEnumerable<Movie> GetPagedByGenre(int page, int pageSize, int selectedGenreId);
        public IEnumerable<Movie> GetPaged(int page, int pageSize);
        public Movie GetMovieById(int movieId);
        public IEnumerable<Movie> GetHighestGrossingMovies();

        public MoviesAndGenresDto GetMoviesAndGenresDto(int page, int pageSize, int selectedGenreId);
        public MovieDetailsDto GetMovieDetails(int movieId);
    }
}
