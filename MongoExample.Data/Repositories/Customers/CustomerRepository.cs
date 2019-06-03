using MongoExample.Data.Interfaces.Customers;
using MongoExample.Domain.Models.Customers;
using MongoExample.Infra.CrossCutting.AppSettings;

namespace MongoExample.Data.Repositories.Customers
{
    public class CustomerRepository : BaseCrudRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository() : base(AppSettings.CustomerCollectionName)
        {
        }
    }
}
