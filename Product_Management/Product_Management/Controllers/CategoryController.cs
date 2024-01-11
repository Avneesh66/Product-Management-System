using Microsoft.AspNetCore.Mvc;
using Product_Management.Models.DTO;
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
            var data = await _category.GetCategories();
            return View(data);
        }
        public IActionResult AddCategory()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    int id = await _category.AddCategory(model);
                    if (id == 0)
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

        public async Task<IActionResult> EditCategory(int id)
        {

            CategoryModel category = new CategoryModel();
            try
            { 
               
                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    category=await _category.getCategoryById(id);
                    if (category == null)
                    {
                        return NotFound();
                    }
                   
                }

            }
            catch (Exception)
            {
                throw;
            }

            return View(category);

        }


        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    bool status = await _category.UpdateCategory(model);
                    if (status)
                    {
                        TempData["msgSuccess"] = "Your Record has been Successfully updated !";
                    }
                    else
                    {
                        TempData["msgError"] = "Record has not been updated !";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("getCategoryList", "Category");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                bool isDeleted = await _category.DeleteCategory(id);

                if (isDeleted)
                {
                    TempData["msgSuccess"] = "Category deleted successfully";
                }
                else
                {
                    TempData["msgError"] = "Category not found";
                    
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
