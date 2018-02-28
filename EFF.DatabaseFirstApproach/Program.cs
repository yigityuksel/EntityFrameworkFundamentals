using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFF.DatabaseFirstApproach
{
    class Program
    {
        static void Main(string[] args)
        {

            var databaseContext = new DBFirstApproachDatabaseEntities();
            
            var post = new Post()
            {
                Body = "test",
                DatePublished = DateTime.Now,
                Title = "test title",
                Id = 1
            };

            databaseContext.Posts.Add(post);
            databaseContext.SaveChanges();

        }
    }
}
