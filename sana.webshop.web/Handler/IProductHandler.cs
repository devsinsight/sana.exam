using sana.webshop.web.Command;

namespace sana.webshop.web.Handler
{
    public interface IProductHandler : 
        ICommandHandler<CreateProduct>
    {
    }
}
