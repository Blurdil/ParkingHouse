using ParkingHouse.Helper;
using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.ViewModels.ParkingHouse
{
    public class ReceiptViewModel
    {
        public int ReceiptNumber { get; set; }
        public string RegNr { get; set; }
        public DateTime ParkingTimeStart { get; set; }
        public string Duration { get; set; }
        public int Cost { get; set; }

        public int getReciptNumber()
        {
            var random = new Random();
            int number = random.Next(1000, 9999);
            return number;
        }

        public string getDuration(DateTime parkingTimeStart, DateTime parkingTimeStop)
        {
            int days = (parkingTimeStop - parkingTimeStart).Days;
            int hours = (parkingTimeStop - parkingTimeStart).Hours;
            int minuts =  (parkingTimeStop - parkingTimeStart).Minutes;
            string duration = days.ToString() + " Dagar " + hours.ToString() + " Timmar " + minuts.ToString() + " Minuter.";
            return duration;
        }

        public int getPayed(DateTime parkingTimeStart, DateTime parkingTimeStop)
        {
            int days = (parkingTimeStop - parkingTimeStart).Days;
            int hours = (parkingTimeStop - parkingTimeStart).Hours;
            int minuts = (parkingTimeStop - parkingTimeStart).Minutes;
            int costDays = 24 * 60;
            int costHour = 60;
            int costMinut = 1;
            return (costDays * days) + (costHour * hours) + (costMinut * minuts);
        }

        public ReceiptViewModel toViewModel(Garage vehicle)
        {
            ReceiptViewModel model = new ReceiptViewModel
            {
                ReceiptNumber = getReciptNumber(),
                ParkingTimeStart = vehicle.ParkingTimeStart,
                Duration = parkingHouseHelper.duration(vehicle.ParkingTimeStart),
                RegNr = vehicle.RegNr,
                Cost = parkingHouseHelper.getPrice(vehicle.ParkingTimeStart),
            };
            return model;
        }
    }
}