using MongoExample.Domain.Models;

namespace MongoExample.Domain.Interfaces.Services.Customers
{
    public interface ICustomerService
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
