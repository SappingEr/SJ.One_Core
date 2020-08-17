using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data
{
    public class HandTimingConfiguration : IEntityTypeConfiguration<HandTiming>
    {
        public void Configure(EntityTypeBuilder<HandTiming> builder)
        {
            builder.Property(at => at.Lap).HasMaxLength(5);
        }
    }
}
