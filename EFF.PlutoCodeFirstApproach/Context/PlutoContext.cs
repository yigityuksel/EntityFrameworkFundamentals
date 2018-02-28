using System.Data.Entity;
using EFF.PlutoCodeFirstApproach.Domain;

namespace EFF.PlutoCodeFirstApproach.Context
{
    public class PlutoContext : DbContext
    {
        public PlutoContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        
    }
}