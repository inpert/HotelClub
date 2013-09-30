using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HotelClub.Data;
using HotelClub.Interface;

namespace HotelClub.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        protected DbContext Context
        {
            get
            {
                return _context;
            }
        }

        public Repository()
        {
            //Default Context
            this._context = new MainContext();
        }

        public Repository(DbContext context)
        {
            this._context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void Remove(int id)
        {
            _context.Set<T>().Remove(GetById(id));
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Detach(T entity)
        {
            this._context.Entry(entity).State = EntityState.Detached;
        }
    }
}
