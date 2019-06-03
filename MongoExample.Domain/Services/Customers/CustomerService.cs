using MongoExample.CrossCutting.DependencyResolver;
using MongoExample.Data.Interfaces.Customers;
using MongoExample.Domain.Interfaces.Customers;
using MongoExample.Domain.Models.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoExample.Domain.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        public async Task Add(Customer customer)
        {
            if (customer == null || string.IsNullOrWhiteSpace(customer.Name))
            {
                return;
            }

            var repository = Factory.Resolve<ICustomerRepository>();
            repository.StartConnection();
            await repository.Add(customer);
        }

        public async Task Delete(Customer customer)
        {
            if (customer == null || string.IsNullOrWhiteSpace(customer.Id))
            {
                return;
            }

            var repository = Factory.Resolve<ICustomerRepository>();
            repository.StartConnection();
            await repository.Delete(customer);
        }

        public async Task<List<Customer>> GetAll()
        {
            var repository = Factory.Resolve<ICustomerRepository>();
            repository.StartConnection();
            return await repository.GetAll();
        }

        public async Task<Customer> GetBy(string id)
        {
            var repository = Factory.Resolve<ICustomerRepository>();
            repository.StartConnection();
            return await repository.GetBy(id);
        }

        public async Task Update(Customer customer)
        {
            if (customer == null || string.IsNullOrWhiteSpace(customer.Name) || string.IsNullOrWhiteSpace(customer.Id))
            {
                return;
            }

            var repository = Factory.Resolve<ICustomerRepository>();
            repository.StartConnection();
            await repository.Update(customer);
        }
    }
}
