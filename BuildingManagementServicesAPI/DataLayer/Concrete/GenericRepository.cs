using DataLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete
{
    public class GenericRepository<T,TContext> : IGenericRepository<T> 
        where T : class 
        where TContext : DbContext
    {
        protected TContext _context;
        public GenericRepository (TContext context) {
            _context = context;
        }

        public T Add(T entity)
        {

            return _context.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            
            _context.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {

            var getvalue= _context.Set<T>().FirstOrDefault(expression);
            if (getvalue != null)
            {
                return getvalue;
            }
            else
            {
                throw new InvalidOperationException("Not found");
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var items = (dynamic)null;
            items= (expression == null) ? _context.Set<T>().ToList(): _context.Set<T>().Where(expression);
            
            if (items == null)
            {
                throw new InvalidOperationException();
            }
            else { 
                return items; 
            }  
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified; 
            
            _context.SaveChanges();
            return entity;
        }
    }
}
