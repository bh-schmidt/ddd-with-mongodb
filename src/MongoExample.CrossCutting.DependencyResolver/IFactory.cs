namespace MongoExample.CrossCutting.DependencyResolver
{
    public interface IFactory
    {
        T Resolve<T>();
    }
}
