using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SefaYedekSan.WebApp.Models;

namespace SefaYedekSan.WebApp.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();


            builder
                .HasOne(x => x.ParentCategory)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.ParentCategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
