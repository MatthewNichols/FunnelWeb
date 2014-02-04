using System.Collections.Generic;
using System.Linq;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class AdminRepository : BaseRepository<Setting>, IAdminRepository
    {
        private readonly ISiteRepository siteRepository;

        #region Constructors

        public AdminRepository(string connectionString, ISiteRepository siteRepository) : base(connectionString)
        {
            this.siteRepository = siteRepository;
        }

        #endregion

        #region Implementation of IAdminRepository

        public IQueryable<Setting> GetSettings()
        {
            var siteId = this.SiteContext.SiteId;
            var site = siteRepository.Get(siteId);
            return site.Settings.AsQueryable();
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