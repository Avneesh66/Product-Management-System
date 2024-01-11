using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product_Management.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Product_Management.Models.DTO
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string? Name { get; set; }

        public List<ProductModel>?Products { get; set; }
    }
}
