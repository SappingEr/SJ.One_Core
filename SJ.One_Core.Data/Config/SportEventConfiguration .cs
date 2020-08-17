using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class SportEventConfiguration : IEntityTypeConfiguration<SportEvent>
    {
        public void Configure(EntityTypeBuilder<SportEvent> builder)
        {
            builder.Property(e => e.EventName).HasMaxLength(500);
            builder.HasOne(r => r.Locality).WithMany(e => e.LocalitySportEvents)
                .HasForeignKey(i => i.LocalityId);
        }
    }
}
