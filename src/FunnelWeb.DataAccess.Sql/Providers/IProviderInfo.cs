using System.Collections.Generic;

namespace FunnelWeb.DataAccess.Sql.Providers
{
    public interface IProviderInfo<out T>
    {
        IEnumerable<string> Keys { get; }
        T GetProviderByName(string key);
        IProviderMetadata GetMetaData(string key);
    }
}