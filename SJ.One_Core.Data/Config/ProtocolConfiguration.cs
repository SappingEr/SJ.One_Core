using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class ProtocolConfiguration : IEntityTypeConfiguration<Protocol>
    {
        public void Configure(EntityTypeBuilder<Protocol> builder)
        {
            builder.HasOne(d => d.Judge).WithMany(d => d.Protocols)
                .HasForeignKey(d => d.JudgeId);
        }
    }
}
