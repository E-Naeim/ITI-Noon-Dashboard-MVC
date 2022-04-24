using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MainRepository<T> : IMainRepository<T> where T : class
    {
        protected ApplicationDbContext Context;
        protected DbSet<T> Table;

        public MainRepository(ApplicationDbContext _Context)
        {
            Context = _Context;
            Table = Context.Set<T>();
        }

        public void Add(T entity) => Table.Add(entity);

        public T Find(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (includes != null)
                query = includes.Aggregate(query,
                  (current, include) => current.Include(include));

            return query.Where(criteria).FirstOrDefault();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (includes != null)
                query = includes.Aggregate(query,
                  (current, include) => current.Include(include));

            return query.Where(criteria);
        }

        public IQueryable<T> GetAll() => Table;

        public T GetById(int id) => Table.Find(id);

        public void Remove(T entity) => Table.Remove(entity);

        public void RemoveById(int id) => Table.Remove(GetById(id));

        public void Update(T entity) => Context.Update(entity);

    }
}
