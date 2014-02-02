using System.Web;
using FunnelWeb.Domain.Interfaces;
using MongoDB.Bson;

namespace FunnelWeb.Domain.Model
{
    public class SiteContext : ISiteContext
    {
        #region Implementation of ISiteContext

        public ObjectId SiteId
        {
            get
            {
                var httpContext = HttpContext.Current;
                var siteId = httpContext.Session["FunnelWeb_SiteId"];
                if (siteId is ObjectId)
                {
                    return (ObjectId) siteId;
                }

                return new ObjectId();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        public void StoreSiteId(ObjectId siteId)
        {
            var httpContext = HttpContext.Current;
            httpContext.Session["FunnelWeb_SiteId"] = siteId;
        }

        #endregion
    }
}