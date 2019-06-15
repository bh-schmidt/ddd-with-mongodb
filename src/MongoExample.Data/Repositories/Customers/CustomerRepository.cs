using MongoExample.CrossCutting.DependencyResolver;
using MongoExample.Data.Interfaces.Customers;
using MongoExample.Domain.Models.Customers;
using MongoExample.Infra.CrossCutting.AppSettings;

namespace MongoExample.Data.Repositories.Customers
{
    public class CustomerRepository : BaseCrudRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IFactory factory) : base(factory, AppSettings.CustomerCollectionName)
        {
        }
    }
}
