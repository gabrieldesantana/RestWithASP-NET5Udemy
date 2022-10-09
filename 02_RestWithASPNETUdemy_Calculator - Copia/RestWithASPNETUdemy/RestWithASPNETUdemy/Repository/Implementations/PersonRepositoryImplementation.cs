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
    }
}
