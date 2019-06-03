using MongoDB.Driver;

namespace MongoExample.Data.Interfaces.Connections
{
    public interface IRepositoryConnection
    {
        IMongoClient GetMongoClient();
        IMongoDatabase GetMongoDatabase();
    }
}
