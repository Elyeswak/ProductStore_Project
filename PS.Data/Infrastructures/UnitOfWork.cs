using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly IDatabaseFactory factory;
        public UnitOfWork(IDatabaseFactory factoryParam)
        {
            factory = factoryParam;
        }
        public void Commit()
        {
            factory.DataContext.SaveChanges();
        }

        public void Dispose()
        {
            factory.DataContext.Dispose();
        }

        public IRepositoryBase<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(factory);
        }
    }
}
