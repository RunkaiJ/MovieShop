using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApplicationCore.Entities
{
    public class Purchase
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime PurchaseDateTime { get; set; }

        [Column(TypeName = "uniqueidentifier")]
        public Guid PurchaseNumber { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal TotalPrice { get; set; }
    }

}
