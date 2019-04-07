using System.Collections.Generic;

namespace MongoExample.Domain.Interfaces.Repository
{
    public interface IBaseCrudRepository<T>
    {
        List<T> GetAll();
        T GetById(string id);
        T Add(T customer);
        void Update(T customer);
        void Delete(T customer);
    }
}
