using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HotelClub.Interface
{
    public interface IRepository <T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Query(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void Remove(T entity);
        void Save();
        void Detach(T entity);
        void Dispose();
    }
}
