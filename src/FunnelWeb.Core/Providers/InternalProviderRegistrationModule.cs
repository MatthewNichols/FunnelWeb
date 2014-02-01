using Autofac;
using Autofac.Features.Indexed;
using FunnelWeb.Core.Providers.File;
//using FunnelWeb.DataAccess.Sql.Providers;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Settings;

namespace FunnelWeb.Core.Providers
{
    public class InternalProviderRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterFileRepositoryProviders(builder);
        }

        private static void RegisterFileRepositoryProviders(ContainerBuilder builder)
        {
            builder
                .RegisterType<AzureBlobFileRepository>()
                .Named<IFileRepository>(AzureBlobFileRepository.ProviderName)
                .WithMetadata<IProviderMetadata>(c => c.For(m => m.Name, AzureBlobFileRepository.ProviderName))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<FileRepository>()
                .Named<IFileRepository>(FileRepository.ProviderName)
                .WithMetadata<IProviderMetadata>(c => c.For(m => m.Name, FileRepository.ProviderName))
                .InstancePerLifetimeScope();

            builder
                .Register(ProviderInfo.For<IFileRepository>)
                .As<IProviderInfo<IFileRepository>>()
                .SingleInstance();

            builder.Register(
                c =>
                {
                    var providerLookup = c.Resolve<IIndex<string, IFileRepository>>();
                    var funnelWebSettings = c.Resolve<ISettingsProvider>().GetSettings<FunnelWebSettings>();
                    var databaseProvider = funnelWebSettings.StorageProvider;
                    return providerLookup[databaseProvider];
                })
                .As<IFileRepository>()
                .InstancePerLifetimeScope();
        }
    }
}