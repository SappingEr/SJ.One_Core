using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.Property(r => r.Name).HasMaxLength(500);
            builder.Property(r => r.StartNumberCount).HasMaxLength(8);
            builder.Property(r => r.Distance).HasMaxLength(20);
            builder.Property(r => r.LapCount).HasMaxLength(5);
            builder.Property(r => r.CountdownTime).HasMaxLength(10);
            builder.HasOne(r => r.MainJudgeRace).WithMany(u => u.MainJudgeRaces)
                .HasForeignKey(i => i.MainJudgeRaceId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(r => r.SportEvent).WithMany(e => e.RacesEvent)
                .HasForeignKey(i => i.SportEventId).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
