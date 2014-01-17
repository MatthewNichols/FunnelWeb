using System.Collections.Generic;

namespace FunnelWeb.Domain.Interfaces
{
    public interface IProviderInfo<out T>
    {
        IEnumerable<string> Keys { get; }
        T GetProviderByName(string key);
        IProviderMetadata GetMetaData(string key);
    }
}