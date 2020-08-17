using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class User_RaceConfiguration : IEntityTypeConfiguration<User_Race>
    {
        public void Configure(EntityTypeBuilder<User_Race> builder)
        {
            builder.HasKey(t => new { t.UserId, t.RaceId });

            builder.HasOne(ur => ur.User)
                .WithMany(u => u.JudgeRaces)
                .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Race)
                .WithMany(r => r.RaceJudges)
                .HasForeignKey(ur => ur.RaceId);
        }
    }
}
