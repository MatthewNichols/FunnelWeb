using System.Collections.Generic;
using System.Linq;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Domain.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        IQueryable<Setting> GetSettings();

        void Save(IEnumerable<Setting> settings);
        void UpdateCommentCountFor(int entryId);
    }
}
