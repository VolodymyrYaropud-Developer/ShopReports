using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("contact_types")]
    public class ContactType
    {
        [Key]
        [Column("contact_type_id", TypeName = "int")]
        public int Id { get; set; }

        [Column("contact_type_name", TypeName = "varchar(50)")]
        public string Name { get; set; }

        public virtual IList<PersonContact> Contacts { get; set; }
    }
}
