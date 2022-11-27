using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Persistence
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext() { }
        public MSSQLContext(DbContextOptions<MSSQLContext> options) 
            : base(options)
        {

        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<User> Users { get; set; }

    }
}
