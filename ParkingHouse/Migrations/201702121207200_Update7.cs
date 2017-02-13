namespace ParkingHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GarageInformations", "PricePerHour", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GarageInformations", "PricePerHour");
        }
    }
}
