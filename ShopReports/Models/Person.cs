using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ShopReports.Models
{
    [Table("persons")]
    public class Person
    {
        [Key]
        [Column("person_id", TypeName = "int")]
        public int Id { get; set; }

        [Column("person_first_name", TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Column("person_last_name", TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column("person_birth_date", TypeName = "varchar(50)")]
        public string BirthDate { get; set; }

        public virtual IList<PersonContact> Contacts { get; set; }

        public Customer Customer { get; set; }
    }
}
