using System;
using Autofac;
using FunnelWeb.Domain.Interfaces;

namespace FunnelWeb.Domain.Tasks
{
    public class TasksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof (TasksModule).Assembly)
                .AssignableTo<ITask>()
                .InstancePerDependency();

            builder.RegisterGeneric(typeof (TaskExecutor<>)).As(typeof (ITaskExecutor<>))
                .SingleInstance();
        }
    }
}