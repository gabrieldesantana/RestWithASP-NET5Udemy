using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Persistence;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class GenericRepositoryImplementation<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly MSSQLContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepositoryImplementation(MSSQLContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public T FindById(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public T Create(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return entity;

        }
        public T Update(T entity)
        {
            if (!Exists(entity.Id)) 
                return null;

            var result = FindById(entity.Id);
            if (result != null) 
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }  
            }
            return entity;
        }

        public void Delete(long id)
        {
            var result = FindById(id);

            if (result != null) 
            {
                try
                {
                    _dbSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dbSet.Any(x => x.Id.Equals(id));
        }


    }
}
