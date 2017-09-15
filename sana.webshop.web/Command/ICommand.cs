using System;

namespace sana.webshop.web.Command
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
