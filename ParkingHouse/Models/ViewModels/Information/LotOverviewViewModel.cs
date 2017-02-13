using ParkingHouse.Helper;
using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.ViewModels.Information
{
    public class LotOverviewViewModel
    {
        public int Level { get; set; }
        public int ParkingSlotsLevel { get; set; }
        public List<int> Levels { get; set; }

        public List<string> Lots { get; set; }

        public LotOverviewViewModel toViewModel(GarageInformation garage, int level)
        {
            LotOverviewViewModel model = new LotOverviewViewModel();
            model.ParkingSlotsLevel = garage.ParkingSlotsLevel;
            model.Level = level;
            model.Levels = parkingHouseHelper.getLevelsList(garage);

            model.Lots = parkingHouseHelper.getParkingLots(garage, level);
            return model;
        }
    }
}