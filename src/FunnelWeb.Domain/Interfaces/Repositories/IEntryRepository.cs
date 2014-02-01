using System.Linq;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Domain.Interfaces.Repositories
{
    public interface IEntryRepository : IRepository<Entry>
    {
        Entry GetByName(string name);
    }
}
