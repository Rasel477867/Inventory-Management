using Autofac;
using InventoryCore;
using InventoryCore.Not_Mapped;
using InventoryService.Contact;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWeb.Models
{
    public class CategoryModel:Category
    {
        private readonly ICategoryService _categoryService;
        public Pagination? Pagination {  get; set; }
        public CategoryQuery? Categoryquery { get; set; }
        public IEnumerable<Category>? Categories { get; set; }

        public CategoryModel()
        {
            _categoryService=Startup.AutofacContainer.Resolve<ICategoryService>();
        }
        public CategoryModel(Guid id):this()
        {
            var category = GetCategoryByIdAsync(id);
            var categoryEntry = category.Result;
            if (id != null)
            {
                
                Id= categoryEntry.Id;
                Name= categoryEntry.Name;
                Description= categoryEntry.Description;

                IsActive= categoryEntry.IsActive;
                IsDeleted= categoryEntry.IsDeleted;

            }
            
        }
        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            return await _categoryService.GetByIdAsyc(id);
        }
        public async Task<(IEnumerable<Category> Categorys, int TotalCount)> GetCategorysAsync(CategoryQuery categoryQuery, int page, int pageSize)
        {
            return await _categoryService.GetCategorysAsync(categoryQuery, page, pageSize);
        }
        public async Task<Guid> AddCategoryAsync(Category categoryModel)
        {
            base.Id= categoryModel.Id;
            base.Name= categoryModel.Name;
            base.Description= categoryModel.Description;
            base.IsActive= categoryModel.IsActive;
            base.Products = categoryModel.Products;
            base.IsDeleted= categoryModel.IsDeleted;
            return await _categoryService.AddAsync(this);

        }
        public async Task<Guid> UpdateCategoryAsync(Category categoryModel)
        {
            
           await _categoryService.UpdateAsync(categoryModel);
            return base.Id; 
        }
        public async Task<bool> DeleteCategoryAsync(Guid CategoryId)
        {
            return await _categoryService.DeleteAsync(CategoryId);
        }

    }
}
