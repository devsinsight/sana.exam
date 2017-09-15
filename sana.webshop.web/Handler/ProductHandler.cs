using sana.webshop.web.Command;
using sana.webshop.web.Repository;
using System;

namespace sana.webshop.web.Handler
{
    public class ProductHandler : IProductHandler
    {

        private readonly Func<bool, IProductRepository> _repository;

        public ProductHandler(Func<bool, IProductRepository> repository)
        {
            _repository = repository;
        }

        public void Handler(CreateProduct command)
        {
            var repo = _repository(command.IsInMemory);
                
                repo.Add(command.Product);

        }

    }
}
