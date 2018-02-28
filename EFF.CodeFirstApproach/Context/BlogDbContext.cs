using System.Data.Entity;
using EFF.CodeFirstApproach.Model;

namespace EFF.CodeFirstApproach.Context
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}