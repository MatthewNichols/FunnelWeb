using System.Collections.Generic;
using NHibernate;

namespace FunnelWeb.Domain.Interfaces
{
    public interface IQuery<out TResult>
    {
        IEnumerable<TResult> Execute(ISession session, IDatabaseProvider databaseProvider);
    }
}