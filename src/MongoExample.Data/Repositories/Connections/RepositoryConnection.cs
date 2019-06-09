using MongoDB.Driver;
using MongoExample.Data.Interfaces.Connections;
using MongoExample.Infra.CrossCutting.AppSettings;

namespace MongoExample.Data.Repositories.Connections
{
    public class RepositoryConnection : IRepositoryConnection
    {
        private readonly string databaseName;

        private readonly IMongoClient mongoClient;

        public RepositoryConnection()
        {
            mongoClient = new MongoClient(AppSettings.MongoDbConnectionString);
            databaseName = AppSettings.MongoDbDatabaseName;
        }

        public IMongoClient GetMongoClient() => mongoClient;
        public IMongoDatabase GetMongoDatabase() => mongoClient.GetDatabase(databaseName);
    }
}
