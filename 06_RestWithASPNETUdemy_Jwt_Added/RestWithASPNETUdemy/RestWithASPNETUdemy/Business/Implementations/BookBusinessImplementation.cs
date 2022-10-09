using System.Collections.Generic;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;
        private readonly BookConverter _converter;
        public BookBusinessImplementation(IBookRepository repository) 
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll()
        {
            var booksVO = _repository.FindAll();
            return _converter.Parse(booksVO);
        }

        public BookVO FindById(long id)
        {
            var bookVO = _repository.FindById(id);
            return _converter.Parse(bookVO);
        }

        public BookVO Create(BookVO bookVO)
        {
            //Converter o VO em Entidade
            var bookEntity = _converter.Parse(bookVO);
            // Armazenar a entidade criada
            bookEntity = _repository.Create(bookEntity);
            // Converter a Entidade em VO
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO bookVO)
        {
            //Converter o VO em Entidade
            var bookEntity = _converter.Parse(bookVO);
            // Armazenar a entidade criada
            bookEntity = _repository.Update(bookEntity);
            // Converter a Entidade em VO
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
