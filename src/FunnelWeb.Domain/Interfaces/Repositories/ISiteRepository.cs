using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunnelWeb.Domain.Model;
using MongoDB.Bson;

namespace FunnelWeb.Domain.Interfaces.Repositories
{
    public interface ISiteRepository
    {
        Site GetByHostName(string hostName);
        ObjectId GetSiteIdByHostName(string hostName);
        Site Save(Site site);
        Site Get(ObjectId id);
    }
}
