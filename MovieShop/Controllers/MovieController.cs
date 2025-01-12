using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVC.Models;

namespace MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        public IActionResult Index(int page = 1, int pageSize = 32, int selectedGenreId = -1)
        {
            IEnumerable<Movie> movies;

            if (selectedGenreId == -1)
            {
                movies = _movieService.GetPaged(page, pageSize);
            }
            else
            {
                movies = _movieService.GetPagedByGenre(page, pageSize, selectedGenreId);
            }

            var genres = _genreService.GetAll();
            int totalPages = (int) Math.Ceiling((double)_movieService.GetTotalCount() / pageSize);
            MoviesAndGenresViewModel model = new MoviesAndGenresViewModel()
            {
                Movies = movies,
                Genres = genres,
                TotalPage = totalPages,
                CurrentPage = page,
                SelectedGenreId = selectedGenreId
            };

            return View(model);
        }
    }
}
