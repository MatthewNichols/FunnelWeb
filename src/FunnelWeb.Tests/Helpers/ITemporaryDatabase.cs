using System;
using DbUp.Helpers;
using FunnelWeb.DataAccess.Sql.DatabaseDeployer;
using FunnelWeb.Domain.Interfaces;
using NHibernate;

namespace FunnelWeb.Tests.Helpers
{
    public interface ITemporaryDatabase : IDisposable, IConnectionStringSettings
    {
        void WithRepository(Action<IRepository> callback);
        void WithSession(Action<ISession> callback);
        AdHocSqlRunner AdHoc { get; }
        void CreateAndDeploy();
        ScriptedExtension ScriptProviderFor<T>(T extensionWithScripts) where T : IRequireDatabaseScripts;
    }
}