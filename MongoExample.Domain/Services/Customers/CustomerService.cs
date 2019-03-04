using MongoExample.CrossCutting.DependencyResolver;
using MongoExample.Domain.Entities;
using MongoExample.Domain.Interfaces.Repository.Customers;
using MongoExample.Domain.Interfaces.Services.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoExample.Domain.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        public void Add(Customer customer)
        {
            var repository = Factory.Resolve<ICustomerRepository>();
            repository.Add(customer);
        }

        public void Delete(Customer customer)
        {
            var repository = Factory.Resolve<ICustomerRepository>();
            repository.Delete(customer);
        }

        public void Update(Customer customer)
        {
            var repository = Factory.Resolve<ICustomerRepository>();
            repository.Update(customer);
        }
    }
}
