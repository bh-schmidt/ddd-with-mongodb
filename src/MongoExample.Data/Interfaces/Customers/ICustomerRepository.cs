using MongoExample.Domain.Models.Customers;

namespace MongoExample.Data.Interfaces.Customers
{
    public interface ICustomerRepository : IBaseCrudRepository<Customer>
    {
    }
}
