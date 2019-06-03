using Autofac;
using MongoExample.Domain.Interfaces.Customers;
using MongoExample.Domain.Services.Customers;

namespace MongoExample.CrossCutting.IoC.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerService>().As<ICustomerService>();
        }
    }
}
