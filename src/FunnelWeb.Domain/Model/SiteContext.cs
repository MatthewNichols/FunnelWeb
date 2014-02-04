using System.Web;
using FunnelWeb.Domain.Interfaces;
using MongoDB.Bson;

namespace FunnelWeb.Domain.Model
{
    public class SiteContext : ISiteContext
    {
        private string hostName;

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

                return ObjectId.Empty;
            }
        }

        public string HostName
        {
            get
            {
                if (string.IsNullOrEmpty(hostName))
                {
                    var httpContext = HttpContext.Current;
                    hostName = httpContext.Request.Url.Host;
                }

                return hostName;
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