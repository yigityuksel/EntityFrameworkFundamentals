using System.Data.Entity.ModelConfiguration;
using Vidzy.LINQ.Domain;

namespace Vidzy.LINQ.EntityTypeConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
