using System;
using System.ComponentModel.DataAnnotations.Schema;
using RestWithASPNETUdemy.Models.Base;

namespace RestWithASPNETUdemy.Models
{
    [Table("books")]
    public partial class Book : BaseEntity
    {

        [Column("author")]
        public string Author { get; set; }

        [Column("lauch_date")]
        public DateTime LaunchDate { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
        [Column("title")]
        public string Title { get; set; }
    }
}
