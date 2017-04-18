using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xam.Services
{
    public interface IDataStore<T> where T : class, new()
    {
        Task SaveAsync(T item);
        Task DeleteAsync(T item);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> QueryAsync();
    }
}
