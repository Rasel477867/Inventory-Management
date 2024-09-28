using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRepository.Core
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsyc(Guid id);
        Task<List<T>> GetAllListAsync();
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        Task AddAsync(T Entity);
        IQueryable<T> GetAllAsync();


    }
}
