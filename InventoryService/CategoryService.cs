using InventoryCore;
using InventoryRepository.Contacts;
using InventoryService.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IProductUnitOfWork _unitOfWork;
        public CategoryService(IProductUnitOfWork productUnitOfWork)
        {
            _unitOfWork = productUnitOfWork;
        }
        public async Task<Guid> AddAsync(Category Entity)
        {
            await _unitOfWork.CategoryRepository.AddAsync(Entity);
            await _unitOfWork.CompleteAsync();
            return Entity.Id;
        }

        public Task DeleteAsync(Category Entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsyc(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category Entity)
        {
            throw new NotImplementedException();
        }
    }
}
