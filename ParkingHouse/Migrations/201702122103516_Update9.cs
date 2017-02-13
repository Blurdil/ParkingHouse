namespace ParkingHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageInformations", "BanerHeadLine", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageInformations", "BanerHeadLine");
        }
    }
}
