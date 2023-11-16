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
        public DbSet<Product>? TblProducts { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Apply your entity configuration
        //    modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        //    modelBuilder.ApplyConfiguration(new ProductConfiguration());


        //}

    }
}
