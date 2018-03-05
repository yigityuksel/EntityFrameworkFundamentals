using System.Data.Entity.ModelConfiguration;
using EFF.FluentAPI.Domain;

namespace EFF.FluentAPI.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            //general structure
            //table rename

            //keys

            //property configurations (a-z)

            //relationships (a-z)

            ToTable("tbl_Course");

            HasKey(c => c.Id);

            Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(2000);

            HasRequired(a => a.Author) //navigation property
            .WithMany(a => a.Courses) //each author has many courses
            .HasForeignKey(a => a.AuthorId)
            .WillCascadeOnDelete(false);

            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(a => a.Course);

            HasMany(a => a.Tags)
                            .WithMany(a => a.Courses)
                            .Map(a =>
                            {
                                a.ToTable("CourseTags");
                                a.MapLeftKey("CourseId");
                                a.MapRightKey("TagId");
                            });
        }
    }
}