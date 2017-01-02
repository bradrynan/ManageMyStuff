namespace ManageMyStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Webpages",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        WebAddress = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Category = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Webpages");
        }
    }
}
