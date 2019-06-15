using MongoDB.Driver;
using MongoExample.CrossCutting.DependencyResolver;
using MongoExample.Data.Interfaces;
using MongoExample.Data.Interfaces.Connections;
using MongoExample.Data.Repositories.Connections;
using MongoExample.Domain.Models;
using System;

namespace MongoExample.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository where T : BaseModel 
    {
        protected readonly IFactory factory;
        protected readonly string collectionName;
        protected IRepositoryConnection repositoryConnection { get; private set; }
        protected IMongoCollection<T> collection => repositoryConnection?.GetMongoDatabase()?.GetCollection<T>(collectionName);

        public BaseRepository(IFactory factory, string collectionName)
        {
            this.collectionName = collectionName;
            this.factory = factory;
        }

        public IRepositoryConnection GetConnection()
        {
            return repositoryConnection;
        }

        public IRepositoryConnection StartConnection()
        {
            try
            {
                repositoryConnection = factory.Resolve<IRepositoryConnection>();
                return repositoryConnection;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UseConnection(IRepositoryConnection repositoryConnection)
        {
            this.repositoryConnection = repositoryConnection;
        }
    }
}
