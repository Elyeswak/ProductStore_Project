using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service
{
    public interface IProductService : IService<Product>
    {
        IEnumerable<Product> FindMost5ExpensiveProds();
        float UnavailableProductsPercentage();
        //IEnumerable<Product> GetProdsByClient(Client C);
        void DeleteOldProducts();
    }
}
