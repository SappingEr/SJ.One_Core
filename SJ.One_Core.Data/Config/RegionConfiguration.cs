using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region");
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.HasOne(c => c.Country).WithMany(r => r.Regions)
                .HasForeignKey(i => i.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

