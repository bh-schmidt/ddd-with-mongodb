using MongoDB.Driver;
using MongoExample.Data.Repositories.Base;
using MongoExample.Domain.Entities;
using MongoExample.Domain.Interfaces.Repository.Customers;
using System.Collections.Generic;

namespace MongoExample.Data.Repositories.Customers
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository() : base("MongoExampleDb", "Customers")
        {
        }

        public Customer Add(Customer customer)
        {
            _collection.InsertOne(customer);
            return customer;
        }

        public void Delete(Customer customer)
        {
            _collection.DeleteOne(c => c.Id == customer.Id);
        }

        public List<Customer> GetAll()
        {
            var res = _collection.Find(x => true);
            return res.ToList();
        }

        public Customer GetById(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefault();
        }

        public void Update(Customer customer)
        {
            _collection.ReplaceOne(c => c.Id == customer.Id, customer);
        }
    }
}
