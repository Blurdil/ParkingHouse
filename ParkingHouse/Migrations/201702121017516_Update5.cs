namespace ParkingHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageInformations",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        BannerPath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.GarageInformations", "page_id", c => c.Guid());
            CreateIndex("dbo.GarageInformations", "page_id");
            AddForeignKey("dbo.GarageInformations", "page_id", "dbo.PageInformations", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GarageInformations", "page_id", "dbo.PageInformations");
            DropIndex("dbo.GarageInformations", new[] { "page_id" });
            DropColumn("dbo.GarageInformations", "page_id");
            DropTable("dbo.PageInformations");
        }
    }
}
