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

        public DbSet<Person> Persons { get; set; }

    }
}
