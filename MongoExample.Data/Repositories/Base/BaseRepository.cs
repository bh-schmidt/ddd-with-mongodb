using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoExample.Data.Repositories.Base
{
    public class BaseRepository<T> where T : class 
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(string databaseName, string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<T>(collectionName);
        }
    }
}
