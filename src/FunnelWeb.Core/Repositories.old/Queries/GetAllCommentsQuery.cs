using System;
using FunnelWeb.Core.Model;
using FunnelWeb.Core.Providers.Database;
using NHibernate;
using NHibernate.Criterion;

namespace FunnelWeb.Core.Repositories.Queries
{
    public class GetAllCommentsQuery : IPagedQuery<Comment>
    {
        public PagedResult<Comment> Execute(ISession session, IDatabaseProvider databaseProvider, int skip, int take)
        {
            var total = session
                .QueryOver<Comment>()
                .ToRowCountQuery()
                .FutureValue<int>();

            var results = session
                .QueryOver<Comment>()
                .Fetch(x => x.Entry).Eager()
                .OrderBy(x => x.Posted).Desc()
                .Skip(skip)
                .Take(take)
                .List();

            return new PagedResult<Comment>(results, total.Value, skip, take);
        }
    }
}