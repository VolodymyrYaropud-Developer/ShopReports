using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("locations")]
    public class Location
    {
        [Key]
        [Column("location_id", TypeName = "int")]
        public int Id { get; set; }

        [Column("location_address", TypeName = "varchar(50)")]
        public string Address { get; set; }

        [ForeignKey(nameof(City))]
        [Column("location_city_id", TypeName = "int")]
        public int CityId { get; set; }

        public City City { get; set; }

        public virtual IList<SupermarketLocation> Supermarkets { get; set; }
    }
}
