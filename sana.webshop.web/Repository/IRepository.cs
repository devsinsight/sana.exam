using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sana.webshop.web.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T model);
        List<T> GetAll();
    }
}
