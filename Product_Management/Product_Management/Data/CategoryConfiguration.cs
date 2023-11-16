using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product_Management.Models.Domain;

namespace Product_Management.Data
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Table name
            builder.ToTable("Categories");

            // Primary key
            builder.HasKey(c => c.Id);

            // Other configurations, if needed
            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();

            // Relationships (if Category has a navigation property to related entities)
            //builder.HasMany(c => c.Products)
            //       .WithOne(p => p.Category)
            //       .HasForeignKey(p => p.CategoryId)
            //       .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
