﻿using System.ComponentModel.DataAnnotations;

namespace Product_Management.Models.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        // Navigation property for products related to this category
        public ICollection<Product> Products { get; set; }

    }
}
