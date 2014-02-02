using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace FunnelWeb.Domain.Interfaces
{
    public interface ISiteContext
    {
        ObjectId SiteId { get; }
        void StoreSiteId(ObjectId siteId);
    }
}
