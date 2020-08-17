using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class AgeGroup_RaceConfiguration : IEntityTypeConfiguration<AgeGroup_Race>
    {
        public void Configure(EntityTypeBuilder<AgeGroup_Race> builder)
        {
            builder.HasKey(t => new { t.AgeGroupId, t.RaceId });

            builder.HasOne(ar => ar.AgeGroup)
                .WithMany(g => g.Races)
                .HasForeignKey(ar => ar.AgeGroupId);

            builder.HasOne(ur => ur.Race)
                .WithMany(r => r.AgeGroups)
                .HasForeignKey(ur => ur.RaceId);
        }
    }
}
