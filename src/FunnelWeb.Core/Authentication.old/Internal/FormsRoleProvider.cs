using System;
using FunnelWeb.Domain.Interfaces;

namespace FunnelWeb.Core.Authentication.Internal
{
    public class FormsRoleProvider : IRoleProvider
    {
        public bool IsUserInRole(string username, string roleName)
        {
            return true;
        }

        public string[] GetRolesForUser(string username)
        {
            return new[] {"Admin", "Moderator"};
        }
    }
}