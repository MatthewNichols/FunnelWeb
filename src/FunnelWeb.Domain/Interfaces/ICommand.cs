using NHibernate;

namespace FunnelWeb.Domain.Interfaces
{
    public interface ICommand
    {
        void Execute(ISession session);
    }
}