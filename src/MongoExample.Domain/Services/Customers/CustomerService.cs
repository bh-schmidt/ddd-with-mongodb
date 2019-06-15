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
        IFactory factory;

        public CustomerService(IFactory factory)
        {
            this.factory = factory;
        }

        public async Task Add(Customer customer)
        {
            if (customer == null || string.IsNullOrWhiteSpace(customer.Name))
            {
                return;
            }

            var repository = factory.Resolve<ICustomerRepository>();

            repository.StartConnection();
            await repository.Add(customer);
        }

        public async Task Delete(Customer customer)
        {
            if (customer == null || string.IsNullOrWhiteSpace(customer.Id))
            {
                return;
            }

            var repository = factory.Resolve<ICustomerRepository>();
            repository.StartConnection();
            await repository.Delete(customer);
        }

        public async Task<List<Customer>> GetAll()
        {
            var repository = factory.Resolve<ICustomerRepository>();
            repository.StartConnection();
            return await repository.GetAll();
        }

        public async Task<Customer> GetBy(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            var repository = factory.Resolve<ICustomerRepository>();
            repository.StartConnection();
            return await repository.GetBy(id);
        }

        public async Task Update(Customer customer)
        {
            if (customer == null || string.IsNullOrWhiteSpace(customer.Name) || string.IsNullOrWhiteSpace(customer.Id))
            {
                return;
            }

            var repository = factory.Resolve<ICustomerRepository>();
            repository.StartConnection();
            await repository.Update(customer);
        }
    }
}
