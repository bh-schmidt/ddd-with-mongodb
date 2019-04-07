using MongoExample.Domain.Models;
using System.Collections.Generic;

namespace MongoExample.Domain.Interfaces.Repository.Customers
{
    public interface ICustomerRepository : IBaseCrudRepository<Customer>
    {
    }
}
