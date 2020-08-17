using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class StartNumbertConfiguration : IEntityTypeConfiguration<StartNumber>
    {
        public void Configure(EntityTypeBuilder<StartNumber> builder)
        {
            builder.Property(e => e.Number).HasMaxLength(6);
            builder.HasOne(j => j.Judge).WithMany(n => n.StartNumbersJudge)
                .HasForeignKey(i => i.JudgeId);

            builder.HasOne(u => u.User).WithMany(n => n.StartNumbersUser)
                .HasForeignKey(i => i.UserId);

            builder.HasOne(r => r.Race).WithMany(n => n.StartNumbersRace)
                .HasForeignKey(i => i.RaceId);
        }
    }
}
