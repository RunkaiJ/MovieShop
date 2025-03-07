﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class CastDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public string TmdbUrl { get; set; }
        public IEnumerable<MovieDto> Movies { get; set; }
    }

    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
    }
}
