using System.Collections.Generic;

namespace FunnelWeb.Domain.Interfaces
{
    public interface ITask
    {
        IEnumerable<ITaskStep> Execute(Dictionary<string, object> properties);
    }
}