using ParkingHouse.DAL;
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
            GarageIndexViewModel givm = new GarageIndexViewModel();
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.NumberOfLots = NumberOfSlots.numberOfSlots;
            var parkedCars = db.Garages.Count();
            var lastParkedCars = db.Garages.OrderByDescending(x => x.ParkingTimeStart).Take(5).ToList();
            model.Vehicles = givm.ListViewModel(lastParkedCars);
            model.FreeLots = model.NumberOfLots - parkedCars;
            return View(model);
        }

    }
}