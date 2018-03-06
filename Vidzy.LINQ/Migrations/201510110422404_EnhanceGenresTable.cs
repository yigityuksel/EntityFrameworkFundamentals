using System.Data.Entity.Migrations;

namespace Vidzy.LINQ.Migrations
{
    public partial class EnhanceGenresTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String());
        }
    }
}
