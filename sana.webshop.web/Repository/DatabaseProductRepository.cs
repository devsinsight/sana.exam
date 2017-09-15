using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sana.webshop.web.Domain;

namespace sana.webshop.web.Repository
{
    public class DatabaseProductRepository : IProductRepository
    {
        private EFContext db;

        public DatabaseProductRepository(EFContext db)
        {
            this.db = db;
        }


        public void Add(Product model)
        {

            db.Products.Add(model);
            db.SaveChanges();

        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();

        }
    }
}
