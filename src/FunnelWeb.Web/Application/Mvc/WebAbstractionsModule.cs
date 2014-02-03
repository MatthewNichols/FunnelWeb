using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using FunnelWeb.Domain.Interfaces;
using FunnelWeb.Domain.Mvc;

namespace FunnelWeb.Web.Application.Mvc
{
    public class WebAbstractionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SiteIdSetter>()
                .As<ISiteIdSetter>().InstancePerHttpRequest();

            builder.Register<HttpContextBase>(x => new HttpContextWrapper(HttpContext.Current))
                .InstancePerLifetimeScope();

            builder.Register<HttpRequestBase>(x => new HttpContextWrapper(HttpContext.Current).Request)
                .InstancePerLifetimeScope();
        
            builder.Register<HttpServerUtilityBase>(x => new HttpServerUtilityWrapper(HttpContext.Current.Server))
                .InstancePerLifetimeScope();
        }
    }
}