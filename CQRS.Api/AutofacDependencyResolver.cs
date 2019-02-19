using Autofac;
using CQRS.Common;

namespace CQRS.Api
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        private readonly ILifetimeScope lifetimeScope;

        public AutofacDependencyResolver(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public T ResolveOrDefault<T>() where T : class
            => lifetimeScope.ResolveOptional<T>();
    }
}
