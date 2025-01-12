using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Review
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal Rating { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string ReviewText { get; set; }
    }

}
