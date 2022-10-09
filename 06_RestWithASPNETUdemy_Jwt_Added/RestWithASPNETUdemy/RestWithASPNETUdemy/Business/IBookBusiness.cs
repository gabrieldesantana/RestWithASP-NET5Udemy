using System.Collections.Generic;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        List<BookVO> FindAll();
        BookVO FindById(long id);
        BookVO Create(BookVO bookVO);
        BookVO Update(BookVO bookVO);
        void Delete(long id);

    }
}
