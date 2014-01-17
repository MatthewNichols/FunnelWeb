using System.Collections.Generic;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.Web.Areas.Admin.Views.Admin
{
    public class PingbacksModel
    {
        public PingbacksModel(IEnumerable<Pingback> pingbacks)
        {
            Pingbacks = pingbacks;
        }

        public IEnumerable<Pingback> Pingbacks { get; set; }
    }
}