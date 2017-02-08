namespace ParkingHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNr = c.String(),
                        Color = c.String(),
                        NumberOfTyres = c.Int(nullable: false),
                        ParkingTimeStart = c.DateTime(nullable: false),
                        ParkingTimeStop = c.DateTime(nullable: false),
                        VehicleType = c.String(),
                        Fabricate = c.String(),
                        FabricateModel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Garages");
        }
    }
}
