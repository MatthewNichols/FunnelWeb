using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class EntryRevisionRepository : BaseRepository<EntryRevision>, IEntryRevisionRepository
    {
        #region Constructors

        public EntryRevisionRepository(string connectionString) : base(connectionString)
        {}

        #endregion

        public EntryRevision GetByName(string pageName)
        {
            pageName = pageName.ToLower();
            return QueryableCollection.SingleOrDefault(e => e.Name == pageName.Trim().ToLower());
        }

        public EntryRevision GetByNameAndRevision(string pageName, int revision)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EntryRevision> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public IList<EntryRevision> GetFullEntries(bool includeComments = false, string entryStatus = null, bool asc = false)
        {
            throw new NotImplementedException();
        }

        public EntryRevision GetEntryWithPingbacks(string pageName)
        {
            throw new NotImplementedException();
        }

        public override string DefaultCollectionName
        {
            get { return "EntityRevisions"; }
        }
    }
}
