using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class SiteRepository : MongoBase<Site>, ISiteRepository
    {
        #region Constructors

        public SiteRepository(string connectionString) : base(connectionString)
        {}

        #endregion

        public Site GetByHostName(string hostName)
        {
            var site = QueryableCollection.SingleOrDefault(s => s.HostName == hostName.ToLower());
            return site;
        }
        
        public ObjectId GetSiteIdByHostName(string hostName)
        {
            var site = GetByHostName(hostName);
            return site == null ? ObjectId.Empty : site.Id;
        }

        public Site Save(Site site)
        {
            collection.Save(site);
            return site;
        }

        public override string DefaultCollectionName
        {
            get { return "Sites"; }
        }
    }
}
