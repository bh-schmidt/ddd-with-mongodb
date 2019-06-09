using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoExample.Data.Interfaces
{
    public interface IBaseCrudRepository<T> : IBaseRepository
    {
        Task<List<T>> GetAll();
        Task<T> GetBy(string id);
        Task<T> Add(T customer);
        Task Update(T customer);
        Task Delete(T customer);
    }
}
