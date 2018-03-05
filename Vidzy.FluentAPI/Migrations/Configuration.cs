using System.Data.Entity.Migrations;

namespace Vidzy.FluentAPI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Vidzy.FluentAPI.Context.VidzyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidzy.FluentAPI.Context.VidzyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
