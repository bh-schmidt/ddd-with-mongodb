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
        protected IRepositoryConnection repositoryConnection { get; private set; }
        protected readonly string collectionName;
        protected IMongoCollection<T> collection => repositoryConnection?.GetMongoDatabase()?.GetCollection<T>(collectionName);

        public BaseRepository(string collectionName)
        {
            this.collectionName = collectionName;
        }

        public IRepositoryConnection GetConnection()
        {
            return repositoryConnection;
        }

        public IRepositoryConnection StartConnection()
        {
            try
            {
                repositoryConnection = Factory.Resolve<IRepositoryConnection>();
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
