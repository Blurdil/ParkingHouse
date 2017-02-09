namespace ParkingHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Garages", "RegNr", c => c.String(nullable: false));
            AlterColumn("dbo.Garages", "Color", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Garages", "VehicleType", c => c.String(nullable: false));
            AlterColumn("dbo.Garages", "Fabricate", c => c.String(nullable: false));
            AlterColumn("dbo.Garages", "FabricateModel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Garages", "FabricateModel", c => c.String());
            AlterColumn("dbo.Garages", "Fabricate", c => c.String());
            AlterColumn("dbo.Garages", "VehicleType", c => c.String());
            AlterColumn("dbo.Garages", "Color", c => c.String());
            AlterColumn("dbo.Garages", "RegNr", c => c.String());
        }
    }
}
