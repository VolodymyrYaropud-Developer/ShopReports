using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopReports.Models
{
    [Table("person_contacts")]
    public class PersonContact
    {
        [Key]
        [Column("person_contact_id", TypeName = "int")]
        public int Id { get; set; }

        [ForeignKey(nameof(Person))]
        [Column("person_id", TypeName = "int")]
        public int PersonId { get; set; }

        [ForeignKey(nameof(ContactType))]
        [Column("contact_type_id", TypeName = "int")]
        public int ContactTypeId { get; set; }

        [Column("contact_value", TypeName = "varchar(50)")]
        public string Value { get; set; }

        public Person Person { get; set; }

        public ContactType Type { get; set; }
    }
}
