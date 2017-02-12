using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.ViewModels.Page
{
    public class HeaderViewModel
    {
        public int NumberOfLots { get; set; }
        public int FreeLots { get; set; }
        public int costHour { get; set; }
        public string ImagePath { get; set; }
        public string BanerHeadLine { get; set; }
        public IList<HeaderViewModel> Vehicles { get; set; }
    }
}