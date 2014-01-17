using FunnelWeb.Domain.Dao;
using NHibernate;

namespace FunnelWeb.Domain.Interfaces
{
    public interface IPagedQuery<T>
    {
        PagedResult<T> Execute(ISession session, IDatabaseProvider databaseProvider, int skip, int take);
    }
}