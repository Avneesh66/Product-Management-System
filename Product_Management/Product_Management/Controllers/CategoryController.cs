using Microsoft.AspNetCore.Mvc;
using Product_Management.Migrations;
using Product_Management.Models.Domain;
using Product_Management.Repositories.Abstract;
using Product_Management.Repositories.Implementation;
using Category = Product_Management.Models.Domain.Category;

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

        public async Task<IActionResult> EditCategory(int id)
        {

            Category category = new Category();
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
        public async Task<IActionResult> EditCategory(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                else
                {
                    bool status = await _category.UpdateCategory(category);
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
