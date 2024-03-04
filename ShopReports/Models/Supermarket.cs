using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("supermarkets")]
    public class Supermarket
    {
        [Key]
        [Column("supermarket_id", TypeName ="int")]
        public int Id { get; set; }

        [Column("supermarket_name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        public virtual IList<SupermarketLocation> Locations { get; set; }
    }
}
