using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data
{
    public class AutoTimingConfiguration : IEntityTypeConfiguration<AutoTiming>
    {
        public void Configure(EntityTypeBuilder<AutoTiming> builder)
        {
            builder.Property(at => at.Lap).HasMaxLength(5);
        }
    }
}
