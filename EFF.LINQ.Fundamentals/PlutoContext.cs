using System.Data.Entity;
using EFF.LINQ.Fundamentals.Domain;
using EFF.LINQ.Fundamentals.EntityConfigurations;

namespace EFF.LINQ.Fundamentals
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=EEFLINQFundamentals")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}
