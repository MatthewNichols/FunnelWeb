using System.Collections.Generic;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class PingbackRepository : BaseRepository<Pingback>, IPingbackRepository
    {
        #region Constructors

        public PingbackRepository(string connectionString) : base(connectionString)
        {}

        #endregion

        public override string DefaultCollectionName
        {
            get { return "Pingbacks"; }
        }
    }
}