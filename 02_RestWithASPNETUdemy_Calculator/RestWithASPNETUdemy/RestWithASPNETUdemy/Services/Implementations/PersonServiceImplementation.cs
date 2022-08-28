using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Persistence;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly MSSQLContext _context;
        //private volatile int count;

        public PersonServiceImplementation(MSSQLContext context) 
        {
            _context = context;
        }





        public Person FindById(long id)
        {
            try
            {
                var person = _context.Persons.SingleOrDefault(p => p.Id == id);

                if (person == null)
                    throw new Exception("O objeto nao pode ser encontrado");

                return person;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<Person> FindAll()
        {
            try
            {
                var persons = _context.Persons.ToList();
                if (persons == null)
                    throw new Exception("Nenhum registro foi localizado");

                return persons;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Person Create(Person person)
        {
            try
            {
                if (person == null)
                    throw new Exception("O objeto nao pode ser vazio");

                _context.Add(person);
                _context.SaveChanges();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return person;
        }



        public Person Update(Person person)
        {

            try
            {
                var personDB = FindById(person.Id);

                if (personDB == null)
                    throw new Exception("O objeto nao pode ser encontrado");

                //personDB.FirstName = person.FirstName;
                //personDB.LastName = person.LastName;
                //personDB.Address = person.Address;
                //personDB.Gender = person.Gender;

                //_context.Entry(person).State = EntityState.Modified;

                //_context.Entry(personDB).State = EntityState.Modified;

                _context.Entry(personDB).CurrentValues.SetValues(person);
                _context.SaveChanges();

                return person;
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
                var person = FindById(id);

                if (person == null)
                    throw new Exception("O objeto nao pode ser encontrado");

                _context.Entry(person).State = EntityState.Deleted;
                _context.SaveChanges();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
