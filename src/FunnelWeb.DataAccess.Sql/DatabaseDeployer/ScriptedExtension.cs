using System.Reflection;
using DbUp.Engine;
using FunnelWeb.Domain.Interfaces;

namespace FunnelWeb.DataAccess.Sql.DatabaseDeployer
{
    public class ScriptedExtension : IScriptedExtension
    {
        private readonly string sourceIdentifier;
        private readonly Assembly sourceAssembly;
        private readonly IScriptProvider scriptProvider;

        public ScriptedExtension(string sourceIdentifier, Assembly sourceAssembly, IScriptProvider scriptProvider)
        {
            this.sourceIdentifier = sourceIdentifier;
            this.sourceAssembly = sourceAssembly;
            this.scriptProvider = scriptProvider;
        }

        public Assembly SourceAssembly
        {
            get { return sourceAssembly; }
        }

        public string SourceIdentifier
        {
            get { return sourceIdentifier; }
        }

        public IScriptProvider ScriptProvider
        {
            get { return scriptProvider; }
        }
    }
}
