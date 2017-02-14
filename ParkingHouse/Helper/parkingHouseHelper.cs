using ParkingHouse.DAL;
using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Helper
{
    public static class parkingHouseHelper
    {
        private static parkingContext db = new parkingContext();

        public static int numberOfParkingLots(GarageInformation garage)
        {
            return garage.ParkingSlotsLevel * garage.Levels;
        }
        public static int pricePerHour(GarageInformation garage)
        {
            return garage.PricePerHour;
        }

        public static void setGarageIDCookie(string guid)
        {
            HttpCookie GarageID = new HttpCookie("GarageID");
            GarageID.Value = guid;
            GarageID.Expires = DateTime.Now.AddDays(7);
            HttpContext.Current.Response.Cookies.Set(GarageID);
        }

        public static Guid getGarageID()
        {
            var cookie = HttpContext.Current.Request.Cookies.Get("GarageID");
            if (cookie == null)
            {
                Guid guid = new Guid("061c595a-20c1-45c5-93f0-c169fdc2b4c1");
                return guid;
            }
            var id = cookie.Value;
            return Guid.Parse(id);
        }

        public static string duration(DateTime startDate)
        {
            int days = (DateTime.Now - startDate).Days;
            int hours = (DateTime.Now - startDate).Hours;
            int minutes = (DateTime.Now - startDate).Minutes;
            string duration = days + " Dagar " + hours + " Timmar " + minutes + " minuter";
            return duration;
        }

        public static int getPrice(DateTime startDate, GarageInformation garage)
        {
            decimal pricePerHour = (decimal)parkingHouseHelper.pricePerHour(garage);
            decimal minutsHours = 60;
            decimal days = (DateTime.Now - startDate).Days;
            decimal hours = (DateTime.Now - startDate).Hours;
            decimal minutes = (DateTime.Now - startDate).Minutes;
            decimal pricePerDay = (24 * pricePerHour);
            decimal pricePerMinut = pricePerHour / minutsHours;
            decimal toPay = (days * pricePerDay) + (hours * pricePerHour) + (minutes + pricePerMinut);
            return Convert.ToInt32(toPay);
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
                decimal pricePerHour = (decimal)parkingHouseHelper.pricePerHour(vehicle.GarageInformation);
                decimal minutsHours = 60;
                decimal days = (DateTime.Now - vehicle.ParkingTimeStart).Days;
                decimal hours = (DateTime.Now - vehicle.ParkingTimeStart).Hours;
                decimal minutes = (DateTime.Now - vehicle.ParkingTimeStart).Minutes;
                decimal pricePerDay = (24 * pricePerHour);
                decimal pricePerMinut = pricePerHour / minutsHours;
                decimal toPay = (days * pricePerDay) + (hours * pricePerHour) + (minutes + pricePerMinut);
                cash = cash + Convert.ToInt32(toPay);
            }
            return cash;
        }

        public static List<string> getParkingLots(GarageInformation garage)
        {
            List<string> parkings = new List<string>();
            for (var i = 0; i < garage.Levels; i++)
            {

                for (var p = 0; p < garage.ParkingSlotsLevel; p++)
                {
                    string parking = "Våning: " + (i + 1) + " plats: " + (p + 1);
                    var check = garage.Garages.Where(x => x.ParkingLotNr == parking).SingleOrDefault();
                    if (check == null)
                    {
                        parkings.Add(parking);
                    }
                }
            }
            return parkings;
        }

        public static List<string> getParkingLots(GarageInformation garage,int level)
        {
            List<string> parkings = new List<string>();
            for (var p = 0; p < garage.ParkingSlotsLevel; p++)
            {
                string parkingInfo = "Våning: " + level + " plats: " + (p + 1);
                string parking = "";
                var check = garage.Garages.Where(x => x.ParkingLotNr == parkingInfo).SingleOrDefault();
                if (check == null)
                {
                    parking = "<div class='ParkingSlot free'>Plats: " + (p + 1) + "</div>";
                }
                else
                {
                    parking = "<div class='ParkingSlot unFree' onClick='openInfo(regNr=" + check.RegNr + ")'>Plats: " + (p + 1) + "<div class='vehicleInfo'>" + check.RegNr + "</div></div>";
                }
                parkings.Add(parking);
            }
            
            return parkings;
        }

        public static List<int> getLevelsList(GarageInformation garage)
        {
            List<int> levels = new List<int>();
            for(var i = 0; i < garage.Levels; i++)
            {
                int l = i + 1;
                var msg = "Level " + l;
                levels.Add(l);
            }
            return levels;
        }

    }
}