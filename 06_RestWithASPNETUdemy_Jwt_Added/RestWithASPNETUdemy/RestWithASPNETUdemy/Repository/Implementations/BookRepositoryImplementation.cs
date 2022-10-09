using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Persistence;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRepositoryImplementation : GenericRepository<Book>, IBookRepository
    {
        public BookRepositoryImplementation(MSSQLContext context) 
           : base(context) 
        { }

    }
}
