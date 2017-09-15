using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sana.webshop.web.Query
{
    public interface IQuery<T> where T : class
    {
        List<T> GetAll();
    }
}
