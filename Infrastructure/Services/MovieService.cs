using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.DTOs;

namespace Infrastructure.Services
{
    public class MovieService : BaseService<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository)
            : base(movieRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        public IEnumerable<Movie> GetPagedByGenre(int page, int pageSize, int selectedGenreId)
        {
            return _movieRepository.GetPagedByGenre(page, pageSize, selectedGenreId);   
        }
        public IEnumerable<Movie> GetPaged(int page, int pageSize)
        {
            return _movieRepository.GetPaged(page, pageSize);
        }

        public Movie GetMovieById(int movieId)
        {
            return _movieRepository.GetMovieById(movieId);
        }

        public IEnumerable<Movie> GetHighestGrossingMovies()
        {
            return _movieRepository.GetHighestGrossingMovies();
        }

        public MoviesAndGenresDto GetMoviesAndGenresDto(int page, int pageSize, int selectedGenreId)
        {
            IEnumerable<Movie> movies;

            if (selectedGenreId == -1)
            {
                movies = GetPaged(page, pageSize);
            }
            else
            {
                movies = GetPagedByGenre(page, pageSize, selectedGenreId);
            }

            var genres = _genreRepository.GetAll();
            int totalPages = (int)Math.Ceiling((double)GetTotalCount() / pageSize);
            MoviesAndGenresDto model = new MoviesAndGenresDto()
            {
                Movies = movies,
                Genres = genres,
                TotalPage = totalPages,

            };
            return model;
        }

        public MovieDetailsDto GetMovieDetails(int movieId)
        {
            var movie = _movieRepository.GetMovieById(movieId);
            return new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                Price = movie.Price, 
                RunTime = movie.RunTime,
                ReleaseDate = movie.ReleaseDate,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                Genres = movie.Genres?.Select(g => g.Name) ?? Enumerable.Empty<string>(),
                Casts = movie.MovieCasts?.Select(mc => new MovieCastDto
                {
                    Id = mc.CastId,
                    Name = mc.Cast.Name,
                    ProfilePath = mc.Cast.ProfilePath,
                    Character = mc.Character
                }) ?? Enumerable.Empty<MovieCastDto>(),
                Trailers = movie.Trailers?.Select(t => new TrailerDto
                {
                    Name = t.Name,
                    TrailerUrl = t.TrailerUrl
                }) ?? Enumerable.Empty<TrailerDto>(),
                OriginalLanguage = movie.OriginalLanguage,
                CreatedBy = movie.CreatedBy,
                CreatedDate = movie.CreatedDate,
                UpdatedBy = movie.UpdatedBy,
                UpdatedDate = movie.UpdatedDate
            };
        }
    }
}
