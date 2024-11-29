using InventoryCore;
using InventoryCore.Not_Mapped;
using InventoryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWeb.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index(CategoryQuery categoryQuery, int page = 1)
        {
            int pageSize = 4;
            var model = await Task.Run(() => new CategoryModel());
            var (categories, totalCount) = await model.GetCategorysAsync(categoryQuery, page, pageSize);
            model.Pagination=new Pagination(totalCount,page, pageSize);
            model.Categories = categories;

            return View(model);
        }
        public async Task<IActionResult> Add()
        {
            var model= await Task.Run(() => new CategoryModel());
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryModel categoryModel)
        {
            if(ModelState.IsValid)
            {
                var id = await Task.Run(() => new CategoryModel().AddCategoryAsync(categoryModel));
               // TempData["SuccessNotify"] = id != null ? "Category Add Successfully" : null;
                return RedirectToAction("Index");

            }
            return RedirectToAction("Add");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await new CategoryModel().DeleteCategoryAsync(id);
           
            return Json(result);
        }
        public async Task<IActionResult> Edit(Guid Id)
        {
            var category= await Task.Run(() => new CategoryModel(Id));
            return View(category);
        
        
       }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var id = await Task.Run(() => new CategoryModel().UpdateCategoryAsync(category));
               
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await new CategoryModel().GetCategoryByIdAsync(id);
            return Json(result); 
        }


    }
}
