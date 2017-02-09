namespace ParkingHouse.Migrations
{
    using Models.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ParkingHouse.DAL.parkingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ParkingHouse.DAL.parkingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Garages.AddRange(new List<Garage>
            {
                new Garage { Color = "Red", Fabricate = "Volvo", FabricateModel = "V70", NumberOfTyres= 4, ParkingTimeStart = DateTime.Now, RegNr="AAA001", VehicleType = "Car" },
                new Garage { Color = "Yellow", Fabricate = "Saab", FabricateModel = "9000", NumberOfTyres= 4, ParkingTimeStart = DateTime.Now, RegNr="AAA002", VehicleType = "Car" }
            }
            );
        }
    }
}
