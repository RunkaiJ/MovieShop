using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CastRepository : BaseRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext context) : base(context)
        {
        }

        public override Cast GetById(int id)
        {
            return _context.Casts
                .Include(c => c.MovieCasts)
                .ThenInclude(mc => mc.Movie)
                .FirstOrDefault(c => c.Id == id);

        }
    }


}
