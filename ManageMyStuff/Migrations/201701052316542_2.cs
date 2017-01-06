namespace ManageMyStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        UploadFileName = c.String(),
                        FileName = c.String(),
                        Description = c.String(nullable: false),
                        ImagePath = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        TakenBy = c.String(),
                    })
                .PrimaryKey(t => t.PhotoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Photos");
        }
    }
}
