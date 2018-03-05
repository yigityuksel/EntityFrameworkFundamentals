using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using EFF.FluentAPI.Domain;
using EFF.FluentAPI.EntityConfigurations;

namespace EFF.FluentAPI.Context
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("name=FluentAPIDB")
        {

        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }
        /// <summary>
        /// APPLIES FLUENT API OVERRIDES
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }

    }
}