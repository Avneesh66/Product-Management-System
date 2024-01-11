using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Management.Models.Domain
{
    public class Product
    {


        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double PurchagePrice { get; set; }

        public double SalePrice { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime? CreatedDate {  get; set; }
        public DateTime? UpdatedDate { get; set;}

        // Foreign key property
         public int CategoryId { get; set; }

        //Navigation property
        public Category Category { get; set; }

    }
}
