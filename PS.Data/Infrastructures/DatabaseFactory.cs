﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructures
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {

        private PSContext dataContext;
        public PSContext DataContext
        {
            get { return dataContext; }
        }

        public DatabaseFactory() { dataContext = new PSContext(); }

        protected override void DisposeCore()
        {
            base.DisposeCore();
            if (dataContext != null)
            {
                dataContext.Dispose();
            }
        }
    }
}
