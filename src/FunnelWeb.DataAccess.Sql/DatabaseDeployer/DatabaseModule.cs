using System;
using Autofac;
using FunnelWeb.Domain.Interfaces;

namespace FunnelWeb.DataAccess.Sql.DatabaseDeployer
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ApplicationDatabase>()
                .As<IApplicationDatabase>()
                .SingleInstance();

            builder
                .RegisterType<DatabaseUpgradeDetector>()
                .As<IDatabaseUpgradeDetector>()
                .SingleInstance();
        }
    }
}
