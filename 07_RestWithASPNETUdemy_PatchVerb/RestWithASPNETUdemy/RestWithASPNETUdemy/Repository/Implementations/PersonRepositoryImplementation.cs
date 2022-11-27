using System;
using System.Linq;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Persistence;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : GenericRepository<Person>, IPersonRepository
    {

        public PersonRepositoryImplementation(MSSQLContext context) : base(context)
        {
        }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;
            var user = _context.Persons.FirstOrDefault(p => p.Id.Equals(id));
            if (user != null) 
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }
    }
}
