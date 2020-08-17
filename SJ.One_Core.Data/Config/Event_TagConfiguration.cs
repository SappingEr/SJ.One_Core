using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class Event_TagConfiguration : IEntityTypeConfiguration<Event_Tag>
    {
        public void Configure(EntityTypeBuilder<Event_Tag> builder)
        {
            builder.HasKey(t => new { t.EventId, t.TagId });

            builder.HasOne(et => et.SportEvent)
                .WithMany(e => e.Tags)
                .HasForeignKey(ur => ur.TagId);

            builder.HasOne(et => et.Tag)
                .WithMany(t => t.SportEvents)
                .HasForeignKey(pt => pt.EventId);
        }
    }
}
