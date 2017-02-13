namespace ParkingHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GarageInformations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Levels = c.Int(nullable: false),
                        ParkingSlotsLevel = c.Int(nullable: false),
                        ParkingHouseName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Garages", "GarageInformation_Id", c => c.Guid());
            CreateIndex("dbo.Garages", "GarageInformation_Id");
            AddForeignKey("dbo.Garages", "GarageInformation_Id", "dbo.GarageInformations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Garages", "GarageInformation_Id", "dbo.GarageInformations");
            DropIndex("dbo.Garages", new[] { "GarageInformation_Id" });
            DropColumn("dbo.Garages", "GarageInformation_Id");
            DropTable("dbo.GarageInformations");
        }
    }
}
