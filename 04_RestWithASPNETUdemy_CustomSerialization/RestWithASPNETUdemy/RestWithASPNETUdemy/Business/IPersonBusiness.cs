using System.Collections.Generic;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        List<Person> FindAll();
        Person FindById(long id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}
