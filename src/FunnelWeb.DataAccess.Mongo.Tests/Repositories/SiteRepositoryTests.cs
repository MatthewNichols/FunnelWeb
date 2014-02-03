using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnelWeb.DataAccess.Mongo.Repositories;
using FunnelWeb.Domain.Model;
using MongoDB.Bson;
using NUnit.Framework;

namespace FunnelWeb.DataAccess.Mongo.Tests.Repositories
{
    [TestFixture]
    public class SiteRepositoryTests
    {
        [Test]
        [Explicit]
        public void SetUpTestSite()
        {
            const string hostName = "funnelwebmongo";

            var siteRepository = new SiteRepository("mongodb://localhost/funnelweb");

            var objectId = siteRepository.GetSiteIdByHostName(hostName);
            objectId = objectId == ObjectId.Empty ? new ObjectId() : objectId;

            var site = new Site
            {
                Id = objectId,
                HostName = hostName
            };

            siteRepository.Save(site);
        }
    }
}
