using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product_Management.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Product_Management.Models.DTO
{
    public class ProductModel
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter the Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please Enter the Description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please Enter the Purchage Price")]
        [Display(Name = "Purchage Price")]
        public double Purchage_Price { get; set; }
        [Required(ErrorMessage = "Please Enter the Sale Price")]
        [Display(Name = "Sale Price")]
        public double Sale_Price { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Choose the images")]
        [Required]
        public IFormFile Image { get; set; }

        public string?ImageUrl { get; set; }

    }
}
