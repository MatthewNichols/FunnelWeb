using System;
using Autofac;

namespace FunnelWeb.Core.DatabaseDeployer
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
