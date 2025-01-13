using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {

        public MovieRepository(MovieShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetPagedByGenre(int page, int pageSize, int selectedGenreId)
        {
            return _context.Movies
                .OrderBy(m => m.Id)
                .Where(m => m.Genres.Any(g => g.Id == selectedGenreId))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Movie> GetPaged(int page, int pageSize)
        {
            return _context.Movies
                .OrderBy(m => m.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Movie GetMovieById(int movieId)
        {
            return _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
                .Include(m => m.Users)
                .Include(m => m.Reviews)
                .Include(m => m.Purchases)
                .Include(m => m.Trailers)
                .FirstOrDefault(m => m.Id == movieId);
        }

        public IEnumerable<Movie> GetHighestGrossingMovies()
        {
            return _context.Movies.OrderByDescending(m => m.Revenue).ToList();

        }
       

    }
}
