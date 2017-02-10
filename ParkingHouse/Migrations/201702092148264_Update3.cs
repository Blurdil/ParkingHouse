namespace ParkingHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Garages", "ParkingTimeStop");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Garages", "ParkingTimeStop", c => c.DateTime(nullable: false));
        }
    }
}
