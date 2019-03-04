using MongoExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoExample.Domain.Interfaces.Services.Customers
{
    public interface ICustomerService
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
