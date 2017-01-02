namespace ManageMyStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Webpages", "WebAddressDescription", c => c.String(nullable: false));
            AddColumn("dbo.Webpages", "WebAddressExtraDescription", c => c.String());
            AlterColumn("dbo.Webpages", "Category", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Webpages", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Webpages", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Webpages", "Category", c => c.String(maxLength: 20));
            DropColumn("dbo.Webpages", "WebAddressExtraDescription");
            DropColumn("dbo.Webpages", "WebAddressDescription");
        }
    }
}
