using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abstraction.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllItems();
        Task<List<T>> GetItems(int pageSize, int pageNumber);
        Task<int> Count();
    }
}