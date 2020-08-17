using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class LocalityConfiguration : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder.ToTable("Locality");
            builder.Property(l => l.Name).HasMaxLength(50);
            builder.HasOne(l => l.Region).WithMany(l => l.Localities)
                .HasForeignKey(l => l.RegionId);
        }
    }
}
