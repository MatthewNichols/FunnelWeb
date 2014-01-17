using System.Collections.Generic;
using FunnelWeb.Core.Providers.Database;
using NHibernate;

namespace FunnelWeb.Core.Repositories
{
    public interface IQuery<out TResult>
    {
        IEnumerable<TResult> Execute(ISession session, IDatabaseProvider databaseProvider);
    }
}