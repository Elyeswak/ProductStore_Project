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
    public class ProductService : Service<Product>, IProductService
    {
        public List<Product> listProduct = new List<Product>();

        public ProductService(IUnitOfWork uow) : base(uow)
        {

        }

        public IEnumerable<Product> FindMost5ExpensiveProds()
        {
            //var req =
            //    from p in listProduct
            //    orderby p.Price descending
            //    select p;

            //return req.Take(5);
            return GetAll().OrderByDescending(P => P.Price).Take(5);
        }

        public float UnavailableProductsPercentage()
        {
            return ((float) GetMany(P => P.Quantity == 0).Count() / GetAll().Count()) * 100;
        }

        //public IEnumerable<Product> GetProdsByClient(Client C)
        //{
        //    IFactureService ifs = new FactureService(uow);
        //    return ifs.GetMany(F => F.CLientFK == C.CIN).Select(F => F.Product);
        //}

        public void DeleteOldProducts()
        {
            IEnumerable<Product> listProduit = GetMany(P => (DateTime.Now - P.DateProd).TotalDays>365);
            foreach(Product produit in listProduit)
            {
                Delete(produit);
            }
            Commit();
        }
    }
}
