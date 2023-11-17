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

        public string Name { get; set; }

        public string Description { get; set; }

        public double Purchage_Price { get; set; }

        public double Sale_Price { get; set; }
        public string Image { get; set; }
        public string Category_Name { get; set; }
    }
}
