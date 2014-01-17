﻿using System;
using FunnelWeb.Core.Model;
using FunnelWeb.Core.Providers.Database;
using NHibernate;
using NHibernate.Criterion;

namespace FunnelWeb.Core.Repositories.Queries
{
    public class GetCommentsQuery : IPagedQuery<Comment>
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
                .Where(x => x.Status != 0)
                .Skip(skip)
                .Take(take)
                .List();

            return new PagedResult<Comment>(results, total.Value, skip, take);
        }
    }
}
