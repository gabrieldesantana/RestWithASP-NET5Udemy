using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Models.Base;
using RestWithASPNETUdemy.Persistence;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly MSSQLContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(MSSQLContext context)
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

        public List<T> FindWithPagedSearch(string query)
        {
            return _dbSet.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using (var connection = _context.Database.GetDbConnection()) 
            {
                connection.Open();
                using (var command = connection.CreateCommand()) 
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }
            return int.Parse(result);
        }
    }
}
