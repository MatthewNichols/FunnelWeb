using System.Collections.Generic;

namespace FunnelWeb.Core.Providers
{
    public interface IProviderInfo<out T>
    {
        IEnumerable<string> Keys { get; }
        T GetProviderByName(string key);
        IProviderMetadata GetMetaData(string key);
    }
}