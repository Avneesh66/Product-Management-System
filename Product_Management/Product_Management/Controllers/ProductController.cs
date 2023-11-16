using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Management.Data;
using Product_Management.Migrations;
using Product_Management.Models.Domain;
using Product_Management.Repositories.Abstract;
using Product = Product_Management.Models.Domain.Product;

namespace Product_Management.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
           
        }
        public async Task<IActionResult> getProductList()
        {
            var data = await _product.getProduct();

            return View(data);
        }
        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            // Assuming you have a DbContext or data service to fetch categories.

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    await _product.AddProduct(product);
                    if (product.Id == 0)
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
    }
}
