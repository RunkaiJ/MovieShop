﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? Price { get; set; } // Added Price
        public int? RunTime { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<MovieCastDto> Casts { get; set; }
        public IEnumerable<TrailerDto> Trailers { get; set; }

        // Additional fields for completeness
        public string OriginalLanguage { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class MovieCastDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public string Character { get; set; }
    }

    public class TrailerDto
    {
        public string Name { get; set; }
        public string TrailerUrl { get; set; }
    }
}

