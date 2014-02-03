using System.Collections.Generic;
using System.Linq;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class AdminRepository : BaseRepository<Setting>, IAdminRepository
    {
        #region Constructors

        public AdminRepository(string connectionString) : base(connectionString)
        {}

        #endregion

        #region Implementation of IAdminRepository

        public IQueryable<Setting> GetSettings()
        {
            throw new System.NotImplementedException();
        }

        public void Save(IEnumerable<Setting> settings)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommentCountFor(int entryId)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        public override string DefaultCollectionName
        {
            get { return "Sites"; }
        }
    }
}