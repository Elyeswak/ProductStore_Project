using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PS.Data.Infrastructures
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IDatabaseFactory _dbFactory;
        DbSet<T> dbset
        {
            get{return _dbFactory.DataContext.Set<T>();}
        }
        public RepositoryBase(IDatabaseFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.AsEnumerable();
        }

        public T GetById(int Id)
        {
            return dbset.Find(Id);
        }

        public T GetById(string Id)
        {
            return dbset.Find(Id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> mydbset = dbset;
            if (where != null)
                mydbset = mydbset.Where(where);
            return mydbset.AsEnumerable();
        }

        public void Update(T entity)
        {
            dbset.Attach(entity);
            _dbFactory.DataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
