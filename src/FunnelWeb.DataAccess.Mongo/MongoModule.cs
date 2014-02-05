using config = System.Configuration.ConfigurationManager;
using Autofac;
using Autofac.Integration.Mvc;
using FunnelWeb.DataAccess.Mongo.Repositories;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Interfaces.Repositories;
using FunnelWeb.Domain.Model;

namespace FunnelWeb.DataAccess.Mongo
{
    public class MongoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = config.ConnectionStrings["funnelWebMongo"].ConnectionString;

            builder.RegisterType<SiteContext>()
                .As<ISiteContext>().InstancePerHttpRequest();

            builder.RegisterType<AdminRepository>()
                .WithParameter("connectionString", connectionString)
                .PropertiesAutowired()
                .As<IAdminRepository>().InstancePerHttpRequest();
            
            builder.RegisterType<SiteRepository>()
                .WithParameter("connectionString", connectionString)
                .As<ISiteRepository>().InstancePerHttpRequest();
            
            builder.RegisterType<CommentRepository>()
                .WithParameter("connectionString", connectionString)
                .As<ICommentRepository>().InstancePerHttpRequest();
            
            builder.RegisterType<EntryRepository>()
                .WithParameter("connectionString", connectionString)
                .As<IEntryRepository>().InstancePerHttpRequest();

            builder.RegisterType<EntryRevisionRepository>()
                .WithParameter("connectionString", connectionString)
                .As<IEntryRevisionRepository>().InstancePerHttpRequest();
            
            builder.RegisterType<EntrySummaryRepository>()
                .WithParameter("connectionString", connectionString)
                .As<IEntrySummaryRepository>().InstancePerHttpRequest();
            
            builder.RegisterType<PingbackRepository>()
                .WithParameter("connectionString", connectionString)
                .As<IPingbackRepository>().InstancePerHttpRequest();
            
            builder.RegisterType<TagRepository>()
                .WithParameter("connectionString", connectionString)
                .As<ITagRepository>().InstancePerHttpRequest();

            //builder.RegisterType<TaskStateRepository>().As<ITaskStateRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<NHibernateRepository>().As<IRepository>().InstancePerLifetimeScope();

            //builder.Register(ConfigureSessionFactory).As<ISessionFactory>().SingleInstance();
            //builder.Register(c => c.Resolve<ISessionFactory>().OpenSession()).As<ISession>().InstancePerLifetimeScope();
        }

    }
}
