using System.Collections.Generic;
using System.Threading.Tasks;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
