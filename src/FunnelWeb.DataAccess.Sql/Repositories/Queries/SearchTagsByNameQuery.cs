using System.Collections.Generic;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Model;
using NHibernate;
using NHibernate.Criterion;

namespace FunnelWeb.DataAccess.Sql.Repositories.Queries
{
    public class SearchTagsByNameQuery :IQuery<Tag>
    {
        private readonly string tagName;

        public SearchTagsByNameQuery(string tagName)
        {
            this.tagName = tagName;
        }

        public string TagName
        {
            get { return tagName; }
        }

        public IEnumerable<Tag> Execute(ISession session, IDatabaseProvider databaseProvider)
        {
            return session
                .QueryOver<Tag>()
                .WhereRestrictionOn(tag => tag.Name).IsLike(TagName, MatchMode.Anywhere)
                .List<Tag>();
        }
    }
}
