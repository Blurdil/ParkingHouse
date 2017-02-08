using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.Entity
{
    public class Garage
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public int NumberOfTyres { get; set; }
        public DateTime ParkingTimeStart { get; set; }
        public DateTime ParkingTimeStop { get; set; }
        public string VehicleType { get; set; }
        public string Fabricate { get; set; }
        public string FabricateModel { get; set; }
    }
}