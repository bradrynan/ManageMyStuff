namespace ManageMyStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Webpages");
            AddColumn("dbo.Webpages", "WebPageID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Webpages", "WebPageID");
            DropColumn("dbo.Webpages", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Webpages", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Webpages");
            DropColumn("dbo.Webpages", "WebPageID");
            AddPrimaryKey("dbo.Webpages", "ID");
        }
    }
}
