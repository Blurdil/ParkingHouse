using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ParkingHouse.DAL;
using ParkingHouse.Models.Entity;
using ParkingHouse.Models.ViewModels.ParkingHouse;

namespace ParkingHouse.Controllers
{
    public class GarageController : Controller
    {
        private parkingContext db = new parkingContext();

        // GET: Garage
        public ActionResult Index()
        {
            var vehicles = db.Garages.ToList();
            var model = new GarageIndexViewModel();
            model.Vehicles = model.ListViewModel(vehicles);

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GarageCreateViewModel model)
        {
            var vehicle = model.ToEntity(model);
            db.Garages.Add(vehicle);
            db.SaveChanges();
            // return RedirectToAction("Index");
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var vechicle = db.Garages.Find(id);
            if (vechicle != null)
            {
                GarageCreateViewModel model = new GarageCreateViewModel();
                model = model.ToViewmodel(vechicle);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GarageCreateViewModel model)
        {
            
            var vehicle = model.ToEntity(model);
            db.Entry(vehicle).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var vechicle = db.Garages.Find(id);
            if(vechicle != null)
            {
                GarageCreateViewModel model = new GarageCreateViewModel();
                model = model.ToViewmodel(vechicle);
                return View(model);
            }
            return View();
        }

        public ActionResult CheckOut(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var vechicle = db.Garages.Find(id);
            if (vechicle != null)
            {
                GarageCreateViewModel model = new GarageCreateViewModel();
                model = model.ToViewmodel(vechicle);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var vehicle = db.Garages.Find(id);
            db.Garages.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
