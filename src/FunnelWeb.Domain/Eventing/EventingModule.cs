using Autofac;

namespace FunnelWeb.Domain.Eventing
{
    public class EventingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<EventPublisher>().As<IEventPublisher>().InstancePerLifetimeScope();
        }
    }
}
