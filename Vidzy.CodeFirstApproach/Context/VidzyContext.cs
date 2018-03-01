using System.Data.Entity;
using Vidzy.CodeFirstApproach.Domain;

namespace Vidzy.CodeFirstApproach.Context
{
    public class VidzyContext : DbContext
    {
        public VidzyContext() : base("name=VidzyConnection")
        {
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}