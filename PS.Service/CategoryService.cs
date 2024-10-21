using Microsoft.EntityFrameworkCore;
using PS.Data;
using PS.Data.Infrastructures;
using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PS.Service
{
    public class CategoryService : Service<Category>,ICategoryService
    {
        public CategoryService(IUnitOfWork uow) : base(uow)
        {

        }

    }
}
