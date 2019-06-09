using Autofac;
using MongoExample.CrossCutting.DependencyResolver;
using MongoExample.CrossCutting.IoC.Modules;

namespace MongoExample.CrossCutting.IoC
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new DataModule());

            Factory.Configure(builder.Build());
        }
    }
}
