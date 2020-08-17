using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class AgeGroupConfiguration : IEntityTypeConfiguration<AgeGroup>
    {
        public void Configure(EntityTypeBuilder<AgeGroup> builder)
        {
            builder.ToTable("AgeGroup");            
            builder.Property(g => g.Name).HasMaxLength(20);
            builder.Property(g => g.From).HasMaxLength(3);
            builder.Property(g => g.To).HasMaxLength(3);
            builder.Property(g => g.Name).HasMaxLength(20);
        }
    }
}
