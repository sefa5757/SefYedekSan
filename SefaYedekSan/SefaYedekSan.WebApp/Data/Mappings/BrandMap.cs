using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SefaYedekSan.WebApp.Models;

namespace SefaYedekSan.WebApp.Data.Mappings
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder
                .HasOne(x => x.CarType)
                .WithMany(x => x.Brands)
                .HasForeignKey(x => x.CarTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Histories)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Models)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
