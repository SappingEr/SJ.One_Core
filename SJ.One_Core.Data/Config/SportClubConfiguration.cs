using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class SportClubConfiguration : IEntityTypeConfiguration<SportClub>
    {
        public void Configure(EntityTypeBuilder<SportClub> builder)
        {            
            builder.Property(c => c.Name).HasMaxLength(300);
            builder.HasOne(l => l.Locality).WithMany(r => r.LocalitySportClubs)
                .HasForeignKey(i => i.LocalityId);
        }
    }
}

