using System.Reflection;
using DbUp.Engine;

namespace FunnelWeb.Domain.Interfaces
{
    public interface IScriptedExtension
    {
        Assembly SourceAssembly { get; }
        string SourceIdentifier { get; }
        IScriptProvider ScriptProvider { get; }
    }
}