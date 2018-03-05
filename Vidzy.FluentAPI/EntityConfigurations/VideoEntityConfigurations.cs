using System.Data.Entity.ModelConfiguration;
using Vidzy.FluentAPI.Domain;

namespace Vidzy.FluentAPI.EntityConfigurations
{
    public class VideoEntityConfigurations : EntityTypeConfiguration<Video>
    {
        public VideoEntityConfigurations()
        {
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(255);

            //HasRequired(a => a.Genre)
            //    .WithMany(g => g.Videos)
            //    .HasForeignKey(v => v.GenreId);

            HasMany(a => a.Tags)
                .WithMany(a => a.Videos)
                .Map(a =>
                {
                    a.ToTable("VideoTags");
                    a.MapLeftKey("VideoId");
                    a.MapRightKey("TagId");
                });
        }
    }
}