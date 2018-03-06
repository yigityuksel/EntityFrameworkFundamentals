using System.Data.Entity.Migrations;

namespace Vidzy.LINQ.Migrations
{
    public partial class AddClassificationToVideosTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Classification", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Classification");
        }
    }
}
