using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product_Management.Models.Domain;

namespace Product_Management.Data
{
    public class ProductManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options) : base(options)
        {

        }   

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }


    }
}
