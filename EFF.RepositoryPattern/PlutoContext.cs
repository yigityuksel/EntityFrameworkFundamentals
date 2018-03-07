using System.Data.Entity;
using EFF.RepositoryPattern.Domain;

namespace EFF.RepositoryPattern
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
           
        }
    }
}
