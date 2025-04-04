using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstraction.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllItemsAsync();
        Task<List<T>> GetItemsAsync(int pageSize, int pageNumber);
        Task<int> CountAsync();
    }
}