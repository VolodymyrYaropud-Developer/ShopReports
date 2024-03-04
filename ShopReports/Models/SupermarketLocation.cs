﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("supermarket_locations")]
    public class SupermarketLocation
    {
        [Key]
        [Column("supermarket_location_id", TypeName = "int")]
        public int Id { get; set; }

        [ForeignKey(nameof(Supermarket))]
        [Column("supermarket_id", TypeName = "int")]
        public int SupermarketId { get; set; }

        [ForeignKey(nameof(Location))]
        [Column("location_id", TypeName = "int")]
        public int LocationId { get; set; }

        public Supermarket Supermarket { get; set; }

        public Location Location { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}
