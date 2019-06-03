using MongoDB.Driver;
using MongoExample.Data.Interfaces;
using MongoExample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoExample.Data.Repositories
{
    public class BaseCrudRepository<T> : BaseRepository<T>, IBaseCrudRepository<T> where T : BaseModel
    {
        public BaseCrudRepository(string collectionName) : base(collectionName) { }

        public virtual async Task<T> Add(T model)
        {
            try
            {
                await collection.InsertOneAsync(model);
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public virtual async Task Delete(T model)
        {
            try
            {
                await collection.DeleteOneAsync(c => c.Id == model.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<List<T>> GetAll()
        {
            try
            {
                var values = await collection.FindAsync(x => true);
                return await values.ToListAsync();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<T> GetBy(string id)
        {
            try
            {
                var values = await collection.FindAsync(c => c.Id == id);
                return await values.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task Update(T customer)
        {
            try
            {
                await collection.ReplaceOneAsync(c => c.Id == customer.Id, customer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
