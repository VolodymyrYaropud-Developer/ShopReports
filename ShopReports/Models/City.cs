using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("location_city")]
    public class City
    {
        [Key]
        [Column("city_id", TypeName ="int")]
        public int Id { get; set; }

        [Column("city", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column("country", TypeName = "varchar(50)")]
        public string Country { get; set; }

        public virtual IList<Location> Locations { get; set; }
    }
}
