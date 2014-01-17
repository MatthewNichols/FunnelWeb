using System;

namespace FunnelWeb.Domain.Repositories
{
    public static class Alias
    {
        public static T For<T>()
        {
            return default(T);
        }
    }
}