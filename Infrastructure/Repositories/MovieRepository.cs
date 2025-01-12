using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {

        public MovieRepository(MovieDbContext context) : base(context)
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
    }
}
