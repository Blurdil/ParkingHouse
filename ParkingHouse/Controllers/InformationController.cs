using ParkingHouse.DAL;
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
        // GET: Information
        public ActionResult Index()
        {
            var vehicle = db.Garages.ToList();
            InformationIndexViewModel model = new InformationIndexViewModel();
            model = model.toViewModel(vehicle);
            return View(model);
        }
    }
}