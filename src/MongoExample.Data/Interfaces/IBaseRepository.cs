using MongoExample.Data.Interfaces.Connections;

namespace MongoExample.Data.Interfaces
{
    public interface IBaseRepository
    {
        IRepositoryConnection GetConnection();
        IRepositoryConnection StartConnection();
        void UseConnection(IRepositoryConnection repositoryConnection);
    }
}
