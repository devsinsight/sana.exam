using sana.webshop.web.Domain;
using sana.webshop.web.Repository;
using System;
using System.Collections.Generic;

namespace sana.webshop.web.Query
{
    public class ProductQuery : IProductQuery
    {

        private readonly Func<bool, IProductRepository> _repository;

        public ProductQuery(Func<bool, IProductRepository> repository)
        {
            _repository = repository;
        }

        public List<Product> GetAll()
        {

            List<Product> products = new List<Product>();
            products.AddRange(_repository(true).GetAll());
            products.AddRange(_repository(false).GetAll());

            return products;
        }
    }
}
