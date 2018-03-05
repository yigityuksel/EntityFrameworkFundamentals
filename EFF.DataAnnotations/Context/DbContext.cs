using System.Data.Entity;
using EFF.DataAnnotations.Domain;

namespace EFF.DataAnnotations.Context
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("name=DataAnnotationDB")
        {
            
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }


    }
}