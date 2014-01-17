using System.Collections.Generic;
using System.Linq;
using FunnelWeb.Core.Model;
using FunnelWeb.Core.Providers.Database;
using NHibernate;
using NHibernate.Linq;

namespace FunnelWeb.Core.Repositories.Queries
{
    public class GetSpamQuery : IQuery<Comment>
    {
        public IEnumerable<Comment> Execute(ISession session, IDatabaseProvider databaseProvider)
        {
            return session
                .Query<Comment>()
                .Where(x => x.Status == 0);
        }
    }
}