namespace ParkingHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Garages", "ParkingLotNr", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Garages", "ParkingLotNr");
        }
    }
}
