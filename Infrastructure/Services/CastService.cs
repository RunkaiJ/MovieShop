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
    public class CastService : BaseService<Cast>, ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository) : base(castRepository)
        {
            _castRepository = castRepository;
        }

        public CastDetailsDto GetCastDetails(int castId)
        {
            var cast = _castRepository.GetById(castId);
            if (cast == null)
            {
                return null;
            }

            return new CastDetailsDto
            {
                Id = cast.Id,
                Name = cast.Name,
                ProfilePath = cast.ProfilePath,
                TmdbUrl = cast.TmdbUrl,
                Movies = cast.MovieCasts.Select(mc => new MovieDto
                {
                    Id = mc.Movie.Id,
                    Title = mc.Movie.Title,
                    PosterUrl = mc.Movie.PosterUrl
                }).ToList()
            };
        }

    }
}
