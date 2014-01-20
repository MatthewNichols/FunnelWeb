using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace FunnelWeb.DataAccess.Mongo
{
    public class MongoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<AdminRepository>().As<IAdminRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<TaskStateRepository>().As<ITaskStateRepository>().InstancePerLifetimeScope();

            //builder.RegisterType<NHibernateRepository>().As<IRepository>().InstancePerLifetimeScope();

            //builder.Register(ConfigureSessionFactory).As<ISessionFactory>().SingleInstance();
            //builder.Register(c => c.Resolve<ISessionFactory>().OpenSession()).As<ISession>().InstancePerLifetimeScope();
        }

    }
}
