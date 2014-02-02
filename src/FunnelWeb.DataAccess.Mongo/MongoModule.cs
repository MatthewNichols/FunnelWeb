using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            builder.RegisterType<SiteContext>().As<ISiteContext>().InstancePerHttpRequest();
            builder.RegisterType<AdminRepository>().As<IAdminRepository>().InstancePerHttpRequest();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>().InstancePerHttpRequest();
            builder.RegisterType<EntryRepository>().As<IEntryRepository>().InstancePerHttpRequest();
            builder.RegisterType<EntryRevisionRepository>().As<IEntryRevisionRepository>().InstancePerHttpRequest();
            builder.RegisterType<EntrySummaryRepository>().As<IEntrySummaryRepository>().InstancePerHttpRequest();
            builder.RegisterType<PingbackRepository>().As<IPingbackRepository>().InstancePerHttpRequest();
            builder.RegisterType<TagRepository>().As<ITagRepository>().InstancePerHttpRequest();
            //builder.RegisterType<TaskStateRepository>().As<ITaskStateRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<NHibernateRepository>().As<IRepository>().InstancePerLifetimeScope();

            //builder.Register(ConfigureSessionFactory).As<ISessionFactory>().SingleInstance();
            //builder.Register(c => c.Resolve<ISessionFactory>().OpenSession()).As<ISession>().InstancePerLifetimeScope();
        }

    }
}
