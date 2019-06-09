using Autofac;

namespace MongoExample.CrossCutting.DependencyResolver
{
    public static class Factory
    {
        private static IContainer Container;

        public static void Configure(IContainer container)
        {
            Container = container;
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
