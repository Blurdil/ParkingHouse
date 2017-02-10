using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.ViewModels.Information
{
    public class InformationIndexViewModel
    {
        public int Cars { get; set; }
        public int TotalNumberOfTyres { get; set; }
        public int CashEarned { get; set; }
        public int Buss { get; set; }
        public int Truck { get; set; }
        public int MotorCycle { get; set; }

        public InformationIndexViewModel toViewModel(List<Garage> garage)
        {
            InformationIndexViewModel model = new InformationIndexViewModel();
            model.CashEarned = model.cashEarned(garage);
            model.TotalNumberOfTyres = model.totalNumberOfTyres(garage);
            model.Cars = garage.Where(x => x.VehicleType == "Bil").Count();
            model.Buss = garage.Where(x => x.VehicleType == "Buss").Count();
            model.Truck = garage.Where(x => x.VehicleType == "Lastbil").Count();
            model.MotorCycle = garage.Where(x => x.VehicleType == "Motorcykel").Count();
            return model;
        }


        public int totalNumberOfTyres(List<Garage> garage)
        {
            int numberOfTyres = 0;
            foreach(var vehicle in garage)
            {
                numberOfTyres = numberOfTyres + vehicle.NumberOfTyres;
            }
            return numberOfTyres;
        }

        public int cashEarned(List<Garage> garage)
        {
            int cash = 0;
            foreach(var vehicle in garage)
            {
                int days = (DateTime.Now - vehicle.ParkingTimeStart ).Days;
                int hours = (DateTime.Now - vehicle.ParkingTimeStart).Hours;
                int minuts = (DateTime.Now - vehicle.ParkingTimeStart).Minutes;
                int costDays = 24 * 60;
                int costHour = 60;
                int costMinut = 1;
                cash = cash + (days * costDays) + (hours * costDays) + (minuts * costDays);
            }
            return cash;
        }
    }
}