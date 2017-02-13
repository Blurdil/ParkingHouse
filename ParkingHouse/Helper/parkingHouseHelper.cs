using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Helper
{
    public static class parkingHouseHelper
    {
        public static int numberOfParkingLots = 60;

        public static int pricePerHour = 30;

        public static string duration(DateTime startDate)
        {
            int days = (DateTime.Now - startDate).Days;
            int hours = (DateTime.Now - startDate).Hours;
            int minutes = (DateTime.Now - startDate).Minutes;
            string duration = days + " Dagar " + hours + " Timmar " + minutes + " minuter";
            return duration;
        }

        public static int getPrice(DateTime startDate)
        {
            int days = (DateTime.Now -startDate).Days;
            int hours = (DateTime.Now - startDate).Hours;
            int minutes = (DateTime.Now - startDate).Minutes;
            int pricePerDay = 24 * parkingHouseHelper.pricePerHour;
            int pricePerMinut = 60 / parkingHouseHelper.pricePerHour;
            int toPay = (days * pricePerDay) + (hours * parkingHouseHelper.pricePerHour) + (minutes + pricePerMinut);
            return toPay;
        }
        public static int totalNumberOfTyres(List<Garage> garage)
        {
            int numberOfTyres = 0;
            foreach (var vehicle in garage)
            {
                numberOfTyres = numberOfTyres + vehicle.NumberOfTyres;
            }
            return numberOfTyres;
        }

        public static int cashEarned(List<Garage> garage)
        {
            int cash = 0;
            foreach (var vehicle in garage)
            {
                int days = (DateTime.Now - vehicle.ParkingTimeStart).Days;
                int hours = (DateTime.Now - vehicle.ParkingTimeStart).Hours;
                int minuts = (DateTime.Now - vehicle.ParkingTimeStart).Minutes;
                int costDays = 24 * 60;
                int costHour = 60;
                cash = cash + (days * costDays) + (hours * costHour) + (minuts / costHour);
            }
            return cash;
        }
    }
}