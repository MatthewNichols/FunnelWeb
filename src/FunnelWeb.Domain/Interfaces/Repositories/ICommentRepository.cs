using System.Collections.Generic;
using System.Linq;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Domain.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetSpam();
    }
}
