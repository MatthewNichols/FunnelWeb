using System;
using FunnelWeb.Core.Providers.Database;
using NHibernate;

namespace FunnelWeb.Core.Repositories
{
    public interface IPagedQuery<T>
    {
        PagedResult<T> Execute(ISession session, IDatabaseProvider databaseProvider, int skip, int take);
    }
}