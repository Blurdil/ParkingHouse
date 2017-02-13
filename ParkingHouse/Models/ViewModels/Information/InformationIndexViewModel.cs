using ParkingHouse.Helper;
using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.ViewModels.Information
{
    public class InformationIndexViewModel
    {
        [Display(Name = "Antal fordon")]
        public int numberOfVehicles { get; set; }
        [Display(Name = "Bilar")]
        public int Cars { get; set; }
        [Display(Name = "Antal däck")]
        public int TotalNumberOfTyres { get; set; }
        [Display(Name = "Inkommande Pengar")]
        public int CashEarned { get; set; }
        [Display(Name = "Buss")]
        public int Buss { get; set; }
        [Display(Name = "Lastbil")]
        public int Truck { get; set; }
        [Display(Name = "Motorcykel")]
        public int MotorCycle { get; set; }

        public InformationIndexViewModel toViewModel(List<Garage> garage)
        {
            InformationIndexViewModel model = new InformationIndexViewModel();
            model.CashEarned = parkingHouseHelper.cashEarned(garage);
            model.TotalNumberOfTyres = parkingHouseHelper.totalNumberOfTyres(garage);
            model.Cars = garage.Where(x => x.VehicleType == "Bil").Count();
            model.Buss = garage.Where(x => x.VehicleType == "Buss").Count();
            model.Truck = garage.Where(x => x.VehicleType == "Lastbil").Count();
            model.MotorCycle = garage.Where(x => x.VehicleType == "Motorcykel").Count();
            model.numberOfVehicles = garage.Count();
            return model;
        }

    }
}