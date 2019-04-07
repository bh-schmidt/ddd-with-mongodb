using MongoDB.Driver;
using MongoExample.Domain.Interfaces.Repository.Customers;
using MongoExample.Domain.Models;
using MongoExample.Infra.CrossCutting.AppSettings;
using System.Collections.Generic;

namespace MongoExample.Data.Repositories.Customers
{
    public class CustomerRepository : BaseCrudRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository() : base(AppSettings.CustomerCollectionName)
        {
        }
    }
}
