using Autofac;

namespace MongoExample.CrossCutting.DependencyResolver
{
    public class Factory : IFactory
    {
        private static IContainer Container;

        public static void Configure(IContainer container)
        {
            Container = container;
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
