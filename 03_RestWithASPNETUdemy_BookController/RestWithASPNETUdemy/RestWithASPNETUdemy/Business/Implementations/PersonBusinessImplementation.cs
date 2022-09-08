using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Persistence;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        //private volatile int count;

        public PersonBusinessImplementation(IPersonRepository repository) 
        {
            _repository = repository;
        }


        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Create(Person person)
        {
            try
            {
                //regras de negocio aqui

                return _repository.Create(person);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public Person Update(Person person)
        {

            try
            {
                return _repository.Update(person);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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
