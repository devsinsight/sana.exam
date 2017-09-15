using sana.webshop.web.Domain;
using sana.webshop.web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sana.webshop.web.Initialize
{
    public class WebshopInitialize
    {

        public static void Initialize(EFContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

        }
    }
}