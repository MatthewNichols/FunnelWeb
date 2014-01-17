using System.Collections.Generic;

namespace FunnelWeb.DataAccess.Sql.Tasks
{
    public interface ITask
    {
        IEnumerable<TaskStep> Execute(Dictionary<string, object> properties);
    }
}