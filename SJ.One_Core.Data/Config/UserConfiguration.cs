using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.Surname).HasMaxLength(50);
            builder.HasOne(l => l.Locality).WithMany(u => u.LocalityUsers)
                .HasForeignKey(i => i.LocalityId);

            builder.HasOne(c => c.SportClub).WithMany(u => u.SportClubUsers)
                .HasForeignKey(i => i.SportClubId);
        }
    }
}
