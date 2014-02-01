using System.Collections.Generic;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Domain.Interfaces.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Tag GetByName(string name);
        IEnumerable<Tag> SearchByName(string namePart);
    }
}
