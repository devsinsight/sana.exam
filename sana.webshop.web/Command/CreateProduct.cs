using sana.webshop.web.Domain;
using System;

namespace sana.webshop.web.Command
{
    public class CreateProduct : ICommand
    {
        public Guid Id => Guid.NewGuid();
        public Product Product { get; set; }
        public bool IsInMemory { get; set; }

    }
}
