using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.Entity
{
    public class GarageInformation
    {

        public Guid Id { get; set; }
        public int Levels { get; set; }
        public int ParkingSlotsLevel { get; set; }
        public string ParkingHouseName { get; set; }
        public int PricePerHour { get; set; }

        public virtual IList<Garage> Garages { get; set; }
        public virtual PageInformation page { get; set; }
    }
}