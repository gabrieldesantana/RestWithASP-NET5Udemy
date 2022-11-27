using System.Collections.Generic;
using RestWithASPNETUdemy.Data.VO;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        List<PersonVO> FindAll();
        PersonVO FindById(long id);
        PersonVO Create(PersonVO personVO);
        PersonVO Update(PersonVO personVO);
        PersonVO Disable(long id);
        void Delete(long id);
    }
}
