using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using sana.webshop.web.Domain;

namespace sana.webshop.web.Repository
{
    public class InMemoryProductRepository : IProductRepository
    {
        private IMemoryCache _cache;
        private MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions();

        public InMemoryProductRepository(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromDays(1));
        }

        public void Add(Product product)
        {
            var products = _cache.Get<List<Product>>("products") ?? new List<Product>();
            products.Add(product);

            _cache.Set("products", products);
        }

        public List<Product> GetAll()
        {
            return _cache.Get<List<Product>>("products") ?? new List<Product>();
        }
    }
}
