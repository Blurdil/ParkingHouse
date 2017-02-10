using ParkingHouse.Models.ViewModels.ParkingHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public int NumberOfLots { get; set; }
        public int FreeLots { get; set; }
        public int costHour { get; set; }
        public IList<GarageIndexViewModel> Vehicles { get; set; }
    }
}