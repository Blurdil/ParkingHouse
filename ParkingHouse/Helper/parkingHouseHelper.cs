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
             return  garage.ParkingSlotsLevel * garage.Levels;
        }
        public static int pricePerHour(GarageInformation garage)
        {
           return garage.PricePerHour;
        }

        public static void  setGarageIDCookie(string guid)
        {
            HttpCookie GarageID = new HttpCookie("GarageID");
            GarageID.Value = guid;
            GarageID.Expires = DateTime.Now.AddDays(7);
            HttpContext.Current.Response.Cookies.Set(GarageID);      
        }

        public static Guid getGarageID()
        {
            var cookie = HttpContext.Current.Request.Cookies.Get("GarageID");
            if(cookie == null)
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
            var pricePerHour = parkingHouseHelper.pricePerHour(garage);
            int days = (DateTime.Now - startDate).Days;
            int hours = (DateTime.Now - startDate).Hours;
            int minutes = (DateTime.Now - startDate).Minutes;
            int pricePerDay = 24 * pricePerHour;
            int pricePerMinut = 60 / pricePerHour;
            int toPay = (days * pricePerDay) + (hours * pricePerHour) + (minutes + pricePerMinut);
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

        public static List<string> getParkingLots(GarageInformation garage)
        {
            List<string> parkings = new List<string>();
            for(var i = 0; i < garage.Levels; i++)
            {
                
                for(var p = 0; p < garage.ParkingSlotsLevel; p++)
                {
                    string parking = "Våning: " + (i + 1) + " plats: " + (p +1);
                    var check = garage.Garages.Where(x => x.ParkingLotNr == parking).SingleOrDefault();
                    if (check == null)
                    {
                        parkings.Add(parking);
                    }
                }
            }
            return parkings;
        }
    }
}