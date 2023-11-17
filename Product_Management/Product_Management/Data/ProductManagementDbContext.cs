using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product_Management.Models.Domain;
using Product_Management.Models.DTO;

namespace Product_Management.Data
{
    public class ProductManagementDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options) : base(options)
        {

        }   

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? TblProducts { get; set; }


    }
}
