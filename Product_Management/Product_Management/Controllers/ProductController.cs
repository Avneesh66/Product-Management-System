using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Management.Data;
using Product_Management.Models.Domain;
using Product_Management.Repositories.Abstract;
using Product_Management.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Product_Management.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductService _product;
        public readonly ICategoryService _category;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProductService product, ICategoryService category, IWebHostEnvironment webHostEnvironment)
        {
            _product = product;
            _category = category;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> getProductList()
        {
            var data = await _product.getProduct();

            return View(data);
        }
        public async Task<IActionResult> AddProduct()
        {
            var data = await _category.GetCategories();
            ViewBag.Categories = new SelectList(data, "Id", "Name");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel model)
        {
            // Assuming you have a DbContext or data service to fetch categories.

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    if (model.Image != null)
                    {
                        string folder = "Product/Photos/";
                        folder += Guid.NewGuid().ToString() + '_' + model.Image.FileName;
                        // Update the model with the saved image URL
                        model.ImageUrl = "/" + folder;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        await model.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));
                       
                    }
                    int id = await _product.AddProduct(model);
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
            return RedirectToAction("getProductList", "Product");
           

        }

        public async Task<IActionResult> EditProduct(int id)
        {

            ProductModel product = new ProductModel();
            try
            {

                if (id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    product = await _product.getProductById(id);
                    if (product == null)
                    {
                        return NotFound();
                    }

                    // Retrieve categories for dropdown list
                    var data = await _category.GetCategories();
                    ViewBag.Categories = new SelectList(data, "Id", "Name", product.CategoryId);


                }

            }
            catch (Exception)
            {
                throw;
            }

            return View(product);

        }


        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    bool status = await _product.UpdateProduct(product);
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
            return RedirectToAction("getProductList", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                bool isDeleted = await _product.DeleteProduct(id);

                if (isDeleted)
                {
                    TempData["msgSuccess"] = "Product deleted successfully";
                }
                else
                {
                    TempData["msgError"] = "Product not found";

                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("getProductList", "Product");
        }
    }
}
