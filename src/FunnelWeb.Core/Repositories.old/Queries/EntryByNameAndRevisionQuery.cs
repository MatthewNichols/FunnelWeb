using System;
using System.Collections.Generic;
using FunnelWeb.Core.Model;
using FunnelWeb.Core.Model.Strings;
using FunnelWeb.Core.Providers.Database;
using FunnelWeb.Core.Repositories.Projections;
using NHibernate;
using NHibernate.Transform;

namespace FunnelWeb.Core.Repositories.Queries
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