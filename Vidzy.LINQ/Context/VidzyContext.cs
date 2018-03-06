using System.Data.Entity;
using Vidzy.LINQ.Domain;
using Vidzy.LINQ.EntityTypeConfigurations;

namespace Vidzy.LINQ.Context
{
    public class VidzyContext : DbContext
    {
        public VidzyContext() : base("name=VidzyConnection")
        {
        }


        public DbSet<Video> Videos { get; set; }    
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}