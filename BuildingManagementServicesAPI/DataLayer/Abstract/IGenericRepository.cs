
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
