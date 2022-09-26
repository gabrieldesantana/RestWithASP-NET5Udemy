using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Persistence;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : GenericRepositoryImplementation<Person>, IPersonRepository
    {

        public PersonRepositoryImplementation(MSSQLContext context) : base(context)
        {
        }
    }
}
