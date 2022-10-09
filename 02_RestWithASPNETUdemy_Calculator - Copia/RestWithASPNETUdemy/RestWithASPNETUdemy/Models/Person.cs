using System.ComponentModel.DataAnnotations.Schema;
using RestWithASPNETUdemy.Models.Base;

namespace RestWithASPNETUdemy.Models
{
    [Table("person")]
    public partial class Person : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
    }
}
