using MongoExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoExample.Domain.Interfaces.Repository.Customers
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(string id);
        Customer Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
