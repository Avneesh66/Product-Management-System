using System.ComponentModel.DataAnnotations;

namespace Product_Management.Models.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter the Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please Enter the Description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please Enter the Purchage Price")]
        public double Purchage_Price { get; set; }
        [Required(ErrorMessage = "Please Enter the Sale Price")]
        public double Sale_Price { get; set; }
        [Display(Name ="Choose the images")]
        public string? Image { get; set; }
        [Required(ErrorMessage = "Please Enter the Category Name")]
        public string? Category_Name { get; set;}
        // Add other properties as needed

        // Foreign key property
       // public int CategoryId { get; set; }

        // Navigation property
        //public Category? Category { get; set; }



    }
}
