using ParkingHouse.DAL;
using ParkingHouse.Helper;
using ParkingHouse.Models;
using ParkingHouse.Models.ViewModels.Home;
using ParkingHouse.Models.ViewModels.ParkingHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingHouse.Controllers
{
    public class HomeController : Controller
    {
        private parkingContext db = new parkingContext();

        public ActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.NumberOfLots = parkingHouseHelper.numberOfParkingLots;
            var parkedCars = db.Garages.Count();
            model.FreeLots = parkingHouseHelper.numberOfParkingLots - parkedCars;
            model.costHour = parkingHouseHelper.pricePerHour;
            return View(model);
        }

        public ActionResult _Image()
        {
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.NumberOfLots = parkingHouseHelper.numberOfParkingLots;
            var parkedCars = db.Garages.Count();
            model.FreeLots = parkingHouseHelper.numberOfParkingLots - parkedCars;
            model.costHour = parkingHouseHelper.pricePerHour;
            return View(model);
        }
    }
}