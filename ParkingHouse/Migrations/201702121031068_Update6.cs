namespace ParkingHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PageInformations", "Url", c => c.String());
            AddColumn("dbo.PageInformations", "InformationBlock", c => c.String());
            AddColumn("dbo.PageInformations", "ContactBlock", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PageInformations", "ContactBlock");
            DropColumn("dbo.PageInformations", "InformationBlock");
            DropColumn("dbo.PageInformations", "Url");
        }
    }
}
