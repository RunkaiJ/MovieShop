using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieShop.Models;

namespace MovieShop.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index(int page = 1, int pageSize = 30, int selectedGenreId = -1)
        {
            var modelDto = _movieService.GetMoviesAndGenresDto(page, pageSize, selectedGenreId);

            MoviesAndGenresViewModel model = new MoviesAndGenresViewModel()
            {
                Movies = modelDto.Movies,
                Genres = modelDto.Genres,
                TotalPage = modelDto.TotalPage,
                CurrentPage = page,
                SelectedGenreId = selectedGenreId
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            // Fetch movie details from the service
            var movieDetailsDto = _movieService.GetMovieDetails(id);

            if (movieDetailsDto == null)
            {
                // Handle not found (return 404 or redirect to a "Not Found" page)
                return NotFound();
            }

            // Map DTO to ViewModel
            var viewModel = new MovieDetailsViewModel
            {
                Id = movieDetailsDto.Id,
                Title = movieDetailsDto.Title,
                Overview = movieDetailsDto.Overview,
                Tagline = movieDetailsDto.Tagline,
                PosterUrl = movieDetailsDto.PosterUrl,
                BackdropUrl = movieDetailsDto.BackdropUrl,
                Price = movieDetailsDto.Price,
                Budget = movieDetailsDto.Budget,
                Revenue = movieDetailsDto.Revenue,
                RunTime = movieDetailsDto.RunTime,
                ReleaseDate = movieDetailsDto.ReleaseDate,
                ImdbUrl = movieDetailsDto.ImdbUrl,
                TmdbUrl = movieDetailsDto.TmdbUrl,
                Genres = movieDetailsDto.Genres,
                Casts = movieDetailsDto.Casts.Select(c => new CastViewModel
                {
                    Id = c.Id, 
                    Name = c.Name,
                    ProfilePath = c.ProfilePath,
                    Character = c.Character
                }),
                Trailers = movieDetailsDto.Trailers.Select(t => new TrailerViewModel
                {
                    Name = t.Name,
                    TrailerUrl = t.TrailerUrl
                })
            };

            return View(viewModel);
        }

    }
}
