using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        //private volatile int count;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository repository) 
        {
            _repository = repository;
            _converter = new PersonConverter();
        }


        public PersonVO FindById(long id)
        {
            var personVO = _repository.FindById(id);
            return _converter.Parse(personVO);
        }

        public List<PersonVO> FindAll()
        {
            var personVO = _repository.FindAll();
            return _converter.Parse(personVO);
        }

        public PersonVO Create(PersonVO personVO)
        {
            try
            {
                //Converter o VO em Entidade
                var personEntity = _converter.Parse(personVO);
                // Armazenar a entidade criada
                personEntity = _repository.Create(personEntity);
                // Converter a Entidade em VO
                return _converter.Parse(personEntity);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public PersonVO Update(PersonVO personVO)
        {

            try
            {
                //Converter o VO em Entidade
                var personEntity = _converter.Parse(personVO);
                // Armazenar a entidade criada
                personEntity = _repository.Update(personEntity);
                // Converter a Entidade em VO
                return _converter.Parse(personEntity);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            try
            {
                _repository.Delete(id);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
