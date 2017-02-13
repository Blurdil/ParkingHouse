using ParkingHouse.DAL;
using ParkingHouse.Helper;
using ParkingHouse.Models.Entity;
using ParkingHouse.Models.ViewModels.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingHouse.Controllers
{
    public class InformationController : Controller
    {
        private parkingContext db = new parkingContext();
        private Guid _Id;
        public GarageInformation _garage;
        public InformationController()
        {
            _Id = parkingHouseHelper.getGarageID();
            _garage = db.GarageInformation.Find(_Id);
        }
        // GET: Information
        public ActionResult Index()
        {
            var vehicle = _garage.Garages.ToList();
            InformationIndexViewModel model = new InformationIndexViewModel();
            model = model.toViewModel(vehicle);
            return View(model);
        }

        public ActionResult LotOverview(int level = 1)
        {
            LotOverviewViewModel model = new LotOverviewViewModel();
            model = model.toViewModel(_garage, level);
            return View(model);
        }
    }
}