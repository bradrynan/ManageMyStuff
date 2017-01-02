namespace ManageMyStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Webpages");
            AlterColumn("dbo.Webpages", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Webpages", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Webpages");
            AlterColumn("dbo.Webpages", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Webpages", "ID");
        }
    }
}
