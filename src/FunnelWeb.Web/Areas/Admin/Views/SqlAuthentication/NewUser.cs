using System.ComponentModel;
using FunnelWeb.Domain.Model.Authentication;

namespace FunnelWeb.Web.Areas.Admin.Views.SqlAuthentication
{
    public class NewUser : User
    {
        [DisplayName("Repeat Password")]
        public virtual string RepeatPassword { get; set; }
    }
}