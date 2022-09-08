using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Persistence;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRepositoryImplementation : GenericRepositoryImplementation<Book>, IBookRepository
    {
        public BookRepositoryImplementation(MSSQLContext context) 
           : base(context) 
        { }

    }
}
