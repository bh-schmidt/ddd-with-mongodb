using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MongoExample.CrossCutting.DependencyResolver;
using MongoExample.CrossCutting.IoC.Modules;
using System;

namespace MongoExample.CrossCutting.IoC
{
    public static class AutofacConfig
    {
        public static IServiceProvider ConfigureContainer(IServiceCollection services)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterType<Factory>().As<IFactory>();
            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new DataModule());

            var container = builder.Build();
            Factory.Configure(container);

            return new AutofacServiceProvider(container);
        }
    }
}
