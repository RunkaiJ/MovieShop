using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService : IService<Movie>
    {
        public IEnumerable<Movie> GetPagedByGenre(int page, int pageSize, int selectedGenreId);
        public IEnumerable<Movie> GetPaged(int page, int pageSize);
    }
}
