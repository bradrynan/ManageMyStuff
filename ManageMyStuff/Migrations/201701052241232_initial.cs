namespace ManageMyStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Webpages",
                c => new
                    {
                        WebPageID = c.Int(nullable: false, identity: true),
                        Category = c.String(nullable: false, maxLength: 50),
                        WebAddress = c.String(nullable: false),
                        WebAddressDescription = c.String(nullable: false),
                        WebAddressExtra = c.String(),
                        WebAddressExtraDescription = c.String(),
                    })
                .PrimaryKey(t => t.WebPageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Webpages");
        }
    }
}
