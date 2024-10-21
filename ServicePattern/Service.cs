using PS.Data.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ServicePattern
{
    public class Service<T> : IService<T> where T : class
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        //static IUnitOfWork uow = new UnitOfWork(factory);
        private readonly IUnitOfWork uow;
        public Service(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        //IRepositoryBase<T> repo = uow.GetRepository<T>();
        

        public virtual void Add(T entity)
        {
            uow.GetRepository<T>().Add(entity);            
        }

        public virtual void Commit()
        {
            uow.Commit();
        }

        public virtual void Delete(T entity)
        {
            uow.GetRepository<T>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            uow.GetRepository<T>().Delete(where);
        }

        public virtual void Dispose()
        {
            uow.Dispose();
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return uow.GetRepository<T>().Get(where);
        }

        public virtual T GetById(int id)
        {
            return uow.GetRepository<T>().GetById(id);
        }

        public virtual T GetById(string id)
        {
            return uow.GetRepository<T>().GetById(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            return uow.GetRepository<T>().GetMany(where);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return uow.GetRepository<T>().GetAll();
        }

        public virtual void Update(T entity)
        {
            uow.GetRepository<T>().Update(entity);
        }
    }
}
