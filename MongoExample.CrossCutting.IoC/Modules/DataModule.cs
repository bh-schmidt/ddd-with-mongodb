using Autofac;
using MongoExample.Data.Repositories.Customers;
using MongoExample.Domain.Interfaces.Repository.Customers;
using System;
using System.Collections.Generic;
using System.Text;

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
