using System;
using System.Collections.Generic;
using System.Data;

namespace FunnelWeb.Domain.Interfaces
{
    /// <summary>
    /// Provides services for dealing with the application database.
    /// </summary>
    public interface IApplicationDatabase
    {
        string[] GetCoreExecutedScripts(Func<IDbConnection> connectionFactory);
        string[] GetCoreRequiredScripts(Func<IDbConnection> connectionFactory);
        string[] GetExtensionExecutedScripts(Func<IDbConnection> connectionFactory, IScriptedExtension extension);
        string[] GetExtensionRequiredScripts(Func<IDbConnection> connectionFactory, IScriptedExtension extension);
    }
}