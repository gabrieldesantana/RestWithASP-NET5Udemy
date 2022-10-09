using System.Collections.Generic;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Repository.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}
