﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }

}
