namespace FunnelWeb.Domain.Interfaces
{
    public interface IRoleProvider
    {
        bool IsUserInRole(string username, string roleName);
        string[] GetRolesForUser(string username);
    }
}
