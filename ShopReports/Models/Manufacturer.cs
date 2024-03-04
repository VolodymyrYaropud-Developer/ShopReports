using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("product_manufacturers")]
    public class Manufacturer
    {
        [Key]
        [Column("manufacturer_id", TypeName = "int")]
        public int Id { get; set; }

        [Column("manufacturer_name", TypeName ="varchar(50)")]
        public string Name { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
