using System.Collections.Generic;
using System.Linq;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Domain.Interfaces.Repositories
{
    public interface IAdminRepository: IRepository<Setting>
    {
        IQueryable<Setting> GetSettings();

        void Save(IEnumerable<Setting> settings);
        void UpdateCommentCountFor(int entryId);
    }
}
