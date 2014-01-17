using System.Linq;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Model;
using NHibernate;
using NHibernate.Linq;

namespace FunnelWeb.DataAccess.Sql.Repositories
{
    public class TaskStateRepository : ITaskStateRepository
    {
        private readonly ISession session;

        public TaskStateRepository(ISession session)
        {
            this.session = session;
        }

        public TaskState Get(int id)
        {
            return session.Load<TaskState>(id);
        }

        public IQueryable<TaskState> GetAll()
        {
            return session.Query<TaskState>();
        }

        public void Save(TaskState state)
        {
            session.SaveOrUpdate(state);
        }
    }
}