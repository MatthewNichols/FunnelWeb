using NHibernate;

namespace FunnelWeb.Core.Repositories
{
    public interface ICommand
    {
        void Execute(ISession session);
    }
}