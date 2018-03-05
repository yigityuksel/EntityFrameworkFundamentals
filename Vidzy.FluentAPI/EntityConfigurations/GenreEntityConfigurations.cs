using System.Data.Entity.ModelConfiguration;
using Vidzy.FluentAPI.Domain;

namespace Vidzy.FluentAPI.EntityConfigurations
{
    public class GenreEntityConfigurations : EntityTypeConfiguration<Genre>
    {
        public GenreEntityConfigurations()
        {
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}