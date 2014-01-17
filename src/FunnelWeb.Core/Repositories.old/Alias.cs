using System;

namespace FunnelWeb.Core.Repositories
{
    public static class Alias
    {
        public static T For<T>()
        {
            return default(T);
        }
    }
}