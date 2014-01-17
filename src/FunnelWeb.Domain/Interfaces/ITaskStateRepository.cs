using System.Linq;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Domain.Interfaces
{
    public interface ITaskStateRepository
    {
        TaskState Get(int id);
        IQueryable<TaskState> GetAll();
        void Save(TaskState state);
    }
}
