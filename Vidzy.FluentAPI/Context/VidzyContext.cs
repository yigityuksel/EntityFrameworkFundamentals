using System.Data.Entity;
using Vidzy.FluentAPI.Domain;
using Vidzy.FluentAPI.EntityConfigurations;

namespace Vidzy.FluentAPI.Context
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
            modelBuilder.Configurations.Add(new VideoEntityConfigurations());
            modelBuilder.Configurations.Add(new GenreEntityConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}