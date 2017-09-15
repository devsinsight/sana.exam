using sana.webshop.web.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sana.webshop.web.Handler
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handler(T command);
    }
}
