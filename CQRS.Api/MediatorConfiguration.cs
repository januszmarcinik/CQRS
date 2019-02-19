using Autofac;
using CQRS.Common;
using CQRS.Core;

namespace CQRS.Api
{
    internal static class MediatorConfiguration
    {
        public static void ConfigureMediator(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            containerBuilder
                .Register(factory =>
                {
                    var lifetimeScope = factory.Resolve<ILifetimeScope>();
                    return new AutofacDependencyResolver(lifetimeScope.BeginLifetimeScope());
                })
                .As<IDependencyResolver>()
                .InstancePerLifetimeScope();

            var handlersAssembly = typeof(InsertMatchResultCommandHandler).Assembly;

            containerBuilder
                .RegisterAssemblyTypes(handlersAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            containerBuilder
                .RegisterAssemblyTypes(handlersAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();
        }
    }
}
