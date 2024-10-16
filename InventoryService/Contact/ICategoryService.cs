using InventoryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Contact
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsyc(Guid id);
        Task<List<Category>> GetAllListAsync();
        Task UpdateAsync(Category Entity);
        Task DeleteAsync(Category Entity);
        Task<Guid> AddAsync(Category Entity);
        IQueryable<Category> GetAllAsync();
    }
}
