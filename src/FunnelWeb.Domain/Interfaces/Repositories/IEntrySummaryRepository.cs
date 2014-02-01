using System.Collections.Generic;
using System.Linq;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Domain.Interfaces.Repositories
{
    public interface IEntrySummaryRepository : IRepository<EntrySummary>
    {
        IList<EntrySummary> GetByTag(string name);
        IList<EntrySummary> GetByStatus(string statusName);
    }
}
