using Autofac;
using Autofac.Features.Indexed;
using FunnelWeb.DataAccess.Sql.Providers.Database;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Settings;

namespace FunnelWeb.DataAccess.Sql.Providers
{
    public class InternalProviderRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterDatabaseProviders(builder);
        }

        private static void RegisterDatabaseProviders(ContainerBuilder builder)
        {
            builder
                .RegisterType<SqlDatabaseProvider>()
                .Named<IDatabaseProvider>("sql")
                .WithMetadata<IProviderMetadata>(c => c.For(m => m.Name, "Sql"));

            builder
                .RegisterType<SqlCeDatabaseProvider>()
                .Named<IDatabaseProvider>("sqlce")
                .WithMetadata<IProviderMetadata>(c => c.For(m => m.Name, "SqlCe"));

            builder
                .Register(ProviderInfo.For<IDatabaseProvider>)
                .As<IProviderInfo<IDatabaseProvider>>()
                .SingleInstance();

            builder.Register(
                c =>
                {
                    var providerLookup = c.Resolve<IIndex<string, IDatabaseProvider>>();
                    var databaseProvider = c.Resolve<IConnectionStringSettings>().DatabaseProvider.ToLower();
                    return providerLookup[databaseProvider];
                })
                .As<IDatabaseProvider>()
                .InstancePerLifetimeScope();
        }
    }
}