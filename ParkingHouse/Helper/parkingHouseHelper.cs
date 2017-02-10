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
            int days = (startDate - DateTime.Now).Days;
            int hours = (startDate - DateTime.Now).Hours;
            int minutes = (startDate - DateTime.Now).Minutes;
            int pricePerDay = 24 * parkingHouseHelper.pricePerHour;
            int pricePerMinut = 60 / parkingHouseHelper.pricePerHour;
            int toPay = (days * pricePerDay) + (hours * parkingHouseHelper.pricePerHour) + (minutes + pricePerMinut);
            return toPay;
        }
    }
}