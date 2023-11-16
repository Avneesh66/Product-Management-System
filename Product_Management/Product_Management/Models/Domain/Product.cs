using System.ComponentModel.DataAnnotations;

namespace Product_Management.Models.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string?  Name { get; set; }
        public string? Description { get; set; }
        public double Purchage_Price { get; set; }
        public double Sale_Price { get; set; }
        public string? Image { get; set; }
        public string? Category_Name { get; set;}
        // Add other properties as needed

        // Foreign key property
       // public int CategoryId { get; set; }

        // Navigation property
        //public Category? Category { get; set; }



    }
}
