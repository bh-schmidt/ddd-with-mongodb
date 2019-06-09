using Autofac;
using MongoExample.Data.Interfaces.Customers;
using MongoExample.Data.Repositories.Customers;

namespace MongoExample.CrossCutting.IoC.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
        }
    }
}
