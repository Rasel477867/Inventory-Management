using InventoryCore;
using InventoryCore.Not_Mapped;
using InventoryRepository.Contacts;
using InventoryService.Contact;
using Microsoft.EntityFrameworkCore;
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
            await _unitOfWork.CategoryRepository.Add(Entity);
            await _unitOfWork.CompleteAsync();
            return Entity.Id;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
           
                await _unitOfWork.CategoryRepository.Delete(id);
                return await _unitOfWork.CompleteAsync();
        }

    

        public async Task<Category> GetByIdAsyc(Guid id)
        {
            return await _unitOfWork.CategoryRepository.GetById(id);
        }

        public async Task<(IEnumerable<Category> Categorys, int TotalCount)> GetCategorysAsync(CategoryQuery categoryQuery, int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;


            var query = _unitOfWork.CategoryRepository.GetAllAsync();
            query = query.Where(x => !x.IsDeleted);
            if (!string.IsNullOrEmpty(categoryQuery.SName))
            {
                query =  query.Where(x => x.Name.Contains(categoryQuery.SName));
            }
            var Categories = await query.Skip(skip).Take(pageSize).ToListAsync();

            var totalCount = await query.CountAsync();

            return (Categories, totalCount);
        }

        public async Task<bool> UpdateAsync(Category Entity)
        {
            await _unitOfWork.CategoryRepository.Update(Entity);
            return await _unitOfWork.CompleteAsync();
        }
    }
}
