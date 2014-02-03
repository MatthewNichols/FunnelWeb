using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;
using MongoDB.Bson;

namespace FunnelWeb.Domain.Mvc
{
    public class SiteIdSetter : ISiteIdSetter
    {
        private readonly ISiteRepository siteRepository;
        private readonly ISiteContext siteContext;

        public SiteIdSetter(ISiteRepository siteRepository, ISiteContext siteContext)
        {
            this.siteRepository = siteRepository;
            this.siteContext = siteContext;
        }

        public void Execute()
        {
            var siteId = siteContext.SiteId;
            if (siteId == ObjectId.Empty)
            {
                siteId = siteRepository.GetSiteIdByHostName(siteContext.HostName);
                siteContext.StoreSiteId(siteId);
            }
        }
    }
}
