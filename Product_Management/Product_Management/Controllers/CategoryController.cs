using Microsoft.AspNetCore.Mvc;
using Product_Management.Models.Domain;
using Product_Management.Repositories.Abstract;

namespace Product_Management.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ICategoryService _category;
        public CategoryController(ICategoryService category) 
        {
            _category=category;
        }
        public async Task<IActionResult> getCategoryList()
        {
            var data = await _category.getCategory();
            return View(data);
        }
        public IActionResult AddCategory()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                else
                {
                    await _category.AddCategory(category);
                    if (category.Id == 0)
                    {
                        TempData["msgError"] = "Record not saved";
                    }
                    else
                    {
                        TempData["msgSuccess"] = "Record Saved Successfully";
                    }
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("getCategoryList", "Category");
        }
    }
}
