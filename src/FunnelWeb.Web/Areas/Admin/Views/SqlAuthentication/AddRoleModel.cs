using System.Collections.Generic;
using FunnelWeb.Domain.Model.Authentication;

namespace FunnelWeb.Web.Areas.Admin.Views.SqlAuthentication
{
    public class AddRoleModel
    {
        public User User { get; set; }
        public IList<Role> Roles { get; set; }
    }
}
