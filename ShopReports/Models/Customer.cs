using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key, ForeignKey(nameof(Person))]
        [Column("customer_id", TypeName = "int")]
        public int Id { get; set; }

        [Column("card_number", TypeName = "int")]
        public string CardNumber { get; set; }

        [Column("discount", TypeName = "int")]
        public decimal Discount { get; set; }

        public Person Person { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}
