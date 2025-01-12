﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(IGenreRepository repository) : base(repository)
        {
        }
    }
}
