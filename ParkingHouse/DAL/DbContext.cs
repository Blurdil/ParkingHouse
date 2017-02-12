using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ParkingHouse.DAL
{
    public class parkingContext : System.Data.Entity.DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public parkingContext() : base("name=DbContext")
        {
        }

        public DbSet<Garage> Garages { get; set; }
        public DbSet<GarageInformation> GarageInformation { get; set; }
        public DbSet<PageInformation> Page { get; set; }
    }
}
