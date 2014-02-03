using System.Collections.Generic;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class EntrySummaryRepository : BaseRepository<EntrySummary>, IEntrySummaryRepository
    {
        #region Constructors

        public EntrySummaryRepository(string connectionString) : base(connectionString)
        {}

        #endregion

        #region Implementation of IEntrySummaryRepository

        public IList<EntrySummary> GetByTag(string name)
        {
            throw new System.NotImplementedException();
        }

        public IList<EntrySummary> GetByStatus(string statusName)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        public override string DefaultCollectionName
        {
            get { return "Entries"; }
        }
    }
}