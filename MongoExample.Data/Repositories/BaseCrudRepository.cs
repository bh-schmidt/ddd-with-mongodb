using MongoDB.Driver;
using MongoExample.Domain.Interfaces.Repository;
using MongoExample.Domain.Models;
using System.Collections.Generic;

namespace MongoExample.Data.Repositories
{
    public class BaseCrudRepository<T> : BaseRepository<T>, IBaseCrudRepository<T> where T : BaseModel
    {
        public BaseCrudRepository(string collectionName) : base(collectionName) { }

        public virtual T Add(T model)
        {
            _collection.InsertOne(model);
            return model;
        }

        public virtual void Delete(T model)
        {
            _collection.DeleteOne(c => c.Id == model.Id);
        }

        public virtual List<T> GetAll()
        {
            var res = _collection.Find(x => true);
            return res.ToList();
        }

        public virtual T GetById(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefault();
        }

        public virtual void Update(T customer)
        {
            _collection.ReplaceOne(c => c.Id == customer.Id, customer);
        }
    }
}
