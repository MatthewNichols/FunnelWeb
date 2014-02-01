using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunnelWeb.Domain.Model;
using FunnelWeb.Domain.Model.Strings;

namespace FunnelWeb.Domain.Interfaces.Repositories
{
    public interface IEntryRevisionRepository : IRepository<EntryRevision>
    {
        EntryRevision GetByName(string pageName);
        EntryRevision GetByNameAndRevision(string pageName, int revision);
        IQueryable<EntryRevision> Search(string searchText);
        IList<EntryRevision> GetFullEntries(bool includeComments = false, string entryStatus = null, bool asc = false);
        EntryRevision GetEntryWithPingbacks(string pageName);
    }
}
