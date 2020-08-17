using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class EventImageConfiguration : IEntityTypeConfiguration<EventImage>
    {
        public void Configure(EntityTypeBuilder<EventImage> builder)
        {
            builder.HasOne(i => i.SportEvent).WithMany(i => i.EventPhotos)
                .HasForeignKey(i => i.SportEventId);
        }
    }
}
