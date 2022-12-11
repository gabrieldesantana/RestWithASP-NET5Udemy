using System;
using System.Collections.Generic;
using RestWithASPNETUdemy.Data.Converter.Implementations;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
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

        public PagedSearchVO<PersonVO> FindWithPagedSearch(
            string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection))
                && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? ((page - 1) * size) : 0;
            //var offset = page > 0 ? (page - 1 * size) : 0;

            string query = @"select * from person p where 1 = 1";
            if (!string.IsNullOrWhiteSpace(name)) query = query + $"and p.first_name like '%{name}%'";
            // query += $" order by p.first_name {sort} limit {size} offset {offset}"; //MySql
            query += $" order by p.first_name {sort} offset {offset} rows fetch next {size} rows only"; //MSSQL

            string countQuery = @"select count (*) from person p where 1 = 1";
            if (!string.IsNullOrWhiteSpace(name)) countQuery = countQuery + $"and p.first_name like '%{name}%'";

            var persons = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO> 
            { 
                CurrentPage = page,
                List = _converter.Parse(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
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

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            var persons = _repository.FindByName(firstName, lastName);
            return _converter.Parse(persons);
        }


    }
}
