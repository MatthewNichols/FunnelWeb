using System;

namespace FunnelWeb.DataAccess.Sql.Repositories
{
    public static class Alias
    {
        public static T For<T>()
        {
            return default(T);
        }
    }
}