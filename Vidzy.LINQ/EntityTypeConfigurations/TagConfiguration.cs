using System.Data.Entity.ModelConfiguration;
using Vidzy.LINQ.Domain;

namespace Vidzy.LINQ.EntityTypeConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
