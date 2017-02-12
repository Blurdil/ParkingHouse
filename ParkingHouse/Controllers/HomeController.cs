using ParkingHouse.DAL;
using ParkingHouse.Helper;
using ParkingHouse.Models;
using ParkingHouse.Models.Entity;
using ParkingHouse.Models.ViewModels.Home;
using ParkingHouse.Models.ViewModels.ParkingHouse;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingHouse.Controllers
{
    public class HomeController : Controller
    {
        private parkingContext db = new parkingContext();
        private Guid _Id;
        public GarageInformation _garage;
        public HomeController()
        {
            _Id = parkingHouseHelper.getGarageID();
            _garage = db.GarageInformation.Find(_Id);
        }

        public ActionResult Index()
        {
            Guid id = parkingHouseHelper.getGarageID();
           
            HomeIndexViewModel model = new HomeIndexViewModel();
            model.NumberOfLots = parkingHouseHelper.numberOfParkingLots(_garage);
            var parkedCars = db.Garages.Where(x => x.GarageInformation.Id == _garage.Id).Count();
            model.FreeLots = parkingHouseHelper.numberOfParkingLots(_garage) - parkedCars;
            model.costHour = parkingHouseHelper.pricePerHour(_garage);
            return View(model);
        }



        public void AddToDb()

        {
            //GarageInformation garageInformation = new GarageInformation
            //{
            //    Id = Guid.NewGuid(),
            //    Levels = 2,
            //    ParkingSlotsLevel = 15,
            //    ParkingHouseName = "Bulldozer Garage 2",

            //};
            //db.GarageInformation.Add(garageInformation);
           // GarageInformation model = db.GarageInformation.Find(_garage);
            //var vehicles = db.Garages.ToList();
            //foreach(var vehicle in vehicles)
            //{
            //    vehicle.GarageInformation = model;
            //    db.Entry(vehicle).State = EntityState.Modified;
            //};

            PageInformation page = new PageInformation
            {
                id = Guid.NewGuid(),
                Url = "/Home",
                BannerPath = "/Media/Image/abandoned-house.jpg",
                InformationBlock = "<h2>Välkommen till vårat garage!</h2><br />" +
                    "<p>Vi hälsar er välkommen till Bulldozer Garage 2," +
                    ".Vi hoppas ni och eran bil kommer trivas även i detta garage.<p>",

                ContactBlock = "<h2>Kontakt</h2> <br />" +
                               "<p>Vid funderingar var god kontakta våran kundtjänst:" +
                                "Telefon: 075 - Bulldozer" +
                                "E - Post: asfalt @bulldozer.nu" +
                                   "Eller kom in till oss på" +
                                   "Asfaltsvägen 23, Asfaltsstaden</p>",
            };
            
            db.Page.Add(page);

            db.SaveChanges();
        }
    }
}