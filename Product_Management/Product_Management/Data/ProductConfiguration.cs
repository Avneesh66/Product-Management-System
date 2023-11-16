using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product_Management.Models.Domain;

namespace Product_Management.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Table name
            builder.ToTable("Products");


            // Primary key
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Purchage_Price).HasColumnName("PurchagePrice");
            builder.Property(p => p.Sale_Price).HasColumnName("SalePrice");
            builder.Property(p => p.Category_Name).HasColumnName("CategoryName");

            //// Relationships (if Product has a foreign key to Category)
            //builder.HasOne(p => p.Category)
            //       .WithMany(c => c.Products)
            //       .HasForeignKey(p => p.CategoryId)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
