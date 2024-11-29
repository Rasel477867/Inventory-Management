using InventoryCore;
using InventoryCore.Not_Mapped;
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
        Task<bool> UpdateAsync(Category Entity);
        Task<bool> DeleteAsync(Guid Id);
        Task<Guid> AddAsync(Category Entity);
        Task<(IEnumerable<Category> Categorys, int TotalCount)> GetCategorysAsync(CategoryQuery categoryQuery, int page, int pageSize);
    }
}
