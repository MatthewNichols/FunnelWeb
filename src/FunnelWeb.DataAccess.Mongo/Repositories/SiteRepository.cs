using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;
using MongoDB.Bson;

namespace FunnelWeb.DataAccess.Mongo.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        public Site GetByHostName(string hostName)
        {
            throw new NotImplementedException();
        }

        public ObjectId GetSiteIdByHostName(string hostName)
        {
            throw new NotImplementedException();
        }
    }
}
