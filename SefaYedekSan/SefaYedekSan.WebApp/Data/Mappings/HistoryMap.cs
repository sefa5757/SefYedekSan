using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SefaYedekSan.WebApp.Models;

namespace SefaYedekSan.WebApp.Data.Mappings
{
    public class HistoryMap : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.Content).IsRequired();
        }
    }
}
