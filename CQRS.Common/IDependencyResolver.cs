namespace CQRS.Common
{
    public interface IDependencyResolver
    {
        T ResolveOrDefault<T>() where T : class;
    }
}
