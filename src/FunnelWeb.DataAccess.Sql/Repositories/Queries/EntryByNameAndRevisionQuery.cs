using System.Collections.Generic;
using FunnelWeb.DataAccess.Sql.Repositories.Projections;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Model;
using FunnelWeb.Domain.Model.Strings;
using NHibernate;
using NHibernate.Transform;

namespace FunnelWeb.DataAccess.Sql.Repositories.Queries
{
    public class EntryByNameAndRevisionQuery : IQuery<EntryRevision>
    {
        private readonly PageName name;
        private readonly int revision;

        public EntryByNameAndRevisionQuery(string name, int revision)
        {
            this.name = name;
            this.revision = revision;
        }

        public PageName PageName
        {
            get { return name; }
        }

        public int Revision
        {
            get { return revision; }
        }

        public IEnumerable<EntryRevision> Execute(ISession session, IDatabaseProvider databaseProvider)
        {
            var entryAlias = Alias.For<Entry>();

            var entryQuery = session
               .QueryOver<Revision>()
               .Where(r => r.RevisionNumber == Revision)
               .Left.JoinQueryOver(r => r.Entry, () => entryAlias)
               .Where(e => e.Name == PageName)
               .SelectList(EntryRevisionProjections.FromRevision(entryAlias))
               .TransformUsing(Transformers.AliasToBean<EntryRevision>());

            return entryQuery.Future<EntryRevision>();
        }
    }
}