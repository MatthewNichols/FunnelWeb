using System;
using System.Collections.Generic;
using FunnelWeb.Domain.Model.Authentication;

namespace FunnelWeb.Web.Areas.Admin.Views.SqlAuthentication
{
    public class IndexModel
    {
        public bool IsUsingSqlAuthentication { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
