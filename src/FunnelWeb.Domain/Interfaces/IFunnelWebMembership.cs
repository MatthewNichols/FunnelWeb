using System.Collections.Generic;
using FunnelWeb.Domain.Model.Authentication;

namespace FunnelWeb.Domain.Interfaces
{
    public interface IFunnelWebMembership
    {
        bool HasAdminAccount();
        User CreateAccount(string name, string email, string username, string password);
        IEnumerable<User> GetUsers();
    }
}