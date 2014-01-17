using Autofac;
using FunnelWeb.Domain.Eventing;
using FunnelWeb.Domain.Extension;
using FunnelWeb.Domain.Interfaces;

namespace FunnelWeb.Extensions.CommentNotification
{
    [FunnelWebExtension(FullName = "Comment Notifications via Email", Publisher = "FunnelWeb", SupportLink = "http://code.google.com/p/funnelweb")]
    public class Extension : IFunnelWebExtension
    {
        public void Initialize(ContainerBuilder builder)
        {
            builder.RegisterType<CommentPostedListener>().As<IEventListener>().InstancePerLifetimeScope();
        }
    }
}