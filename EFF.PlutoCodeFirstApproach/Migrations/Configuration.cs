using System.Collections.Generic;
using EFF.PlutoCodeFirstApproach.Domain;
using System.Data.Entity.Migrations;

namespace EFF.PlutoCodeFirstApproach.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EFF.PlutoCodeFirstApproach.Context.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFF.PlutoCodeFirstApproach.Context.PlutoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Authors.AddOrUpdate(a => a.Name, new Author
            {
                Name = "Author 1",
                Courses = new List<Course>()
                        {
                            new Course()
                            {
                                Name = "Course 1 for AU 1",
                                Description = "Desc"
                            }
                        }
            });

        }
    }
}
