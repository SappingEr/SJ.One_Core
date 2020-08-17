using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data.Config
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {           
            builder.Property(t => t.Name).HasMaxLength(100);            
        }
    }
}
