using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.DTOs;
using MovieShop.Models;

namespace MovieShop.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService) { 
            _castService = castService;
        }
        public IActionResult Details(int id)
        {
            var castDetails = _castService.GetCastDetails(id);

            if (castDetails == null)
            {
                return NotFound();
            }

            var viewModel = new CastDetailsViewModel
            {
                Id = castDetails.Id,
                Name = castDetails.Name,
                ProfilePath = castDetails.ProfilePath,
                TmdbUrl = castDetails.TmdbUrl,
                Movies = castDetails.Movies.Select(m => new MovieViewModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    PosterUrl = m.PosterUrl
                }).ToList()
            };

            return View(viewModel);
        }
    }
}
