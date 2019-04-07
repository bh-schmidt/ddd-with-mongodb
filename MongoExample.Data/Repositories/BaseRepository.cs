using MongoDB.Driver;
using MongoExample.Domain.Models;
using MongoExample.Infra.CrossCutting.AppSettings;

namespace MongoExample.Data.Repositories
{
    public class BaseRepository<T> where T : BaseModel 
    {
        protected readonly IMongoClient _mongoClient;
        protected readonly IMongoDatabase _mongoDatabase;
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(string collectionName)
        {
            _mongoClient = new MongoClient(AppSettings.MongoDbConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(AppSettings.MongoDbDatabaseName);
            _collection = _mongoDatabase.GetCollection<T>(collectionName);
        }
    }
}
