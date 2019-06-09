using MongoExample.Domain.Models;
using MongoExample.Domain.Models.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoExample.Domain.Interfaces.Customers
{
    public interface ICustomerService
    {
        Task Add(Customer customer);
        Task<List<Customer>> GetAll();
        Task<Customer> GetBy(string id);
        Task Update(Customer customer);
        Task Delete(Customer customer);
    }
}
