namespace Vidzy.FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoTags : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagVideos", newName: "VideoTags");
            RenameColumn(table: "dbo.VideoTags", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.VideoTags", name: "Video_Id", newName: "VideoId");
            RenameIndex(table: "dbo.VideoTags", name: "IX_Video_Id", newName: "IX_VideoId");
            RenameIndex(table: "dbo.VideoTags", name: "IX_Tag_Id", newName: "IX_TagId");
            DropPrimaryKey("dbo.VideoTags");
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videos", "Name", c => c.String(nullable: false, maxLength: 255));
            AddPrimaryKey("dbo.VideoTags", new[] { "VideoId", "TagId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.VideoTags");
            AlterColumn("dbo.Videos", "Name", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AddPrimaryKey("dbo.VideoTags", new[] { "Tag_Id", "Video_Id" });
            RenameIndex(table: "dbo.VideoTags", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.VideoTags", name: "IX_VideoId", newName: "IX_Video_Id");
            RenameColumn(table: "dbo.VideoTags", name: "VideoId", newName: "Video_Id");
            RenameColumn(table: "dbo.VideoTags", name: "TagId", newName: "Tag_Id");
            RenameTable(name: "dbo.VideoTags", newName: "TagVideos");
        }
    }
}
