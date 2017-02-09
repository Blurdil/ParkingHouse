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
        public ActionResult Index(string orderBy,string searchTerm)
        {
            IQueryable<Garage> query = db.Garages;
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "regnr":
                        query = query.OrderByDescending(x => x.RegNr);
                        break;

                    case "parkingtimestart":
                        query = query.OrderBy(x => x.ParkingTimeStart);
                        break;

                    case "fabricate":
                        query = query.OrderBy(x => x.Fabricate);
                        break;

                    case "fabricatemodel":
                        query = query.OrderBy(x => x.FabricateModel);
                        break;

                    default:
                        query = query.OrderBy(x => x.ParkingTimeStop);
                        break;
                }
            }
            if(!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.SearchTerm = searchTerm;
                query = query.Where(x => x.RegNr.Contains(searchTerm) || x.Color.Contains(searchTerm) || x.Fabricate.Contains(searchTerm) || x.FabricateModel.Contains(searchTerm) || x.VehicleType.Contains(searchTerm));
            }
            var model = new GarageIndexViewModel();
            model.Vehicles = model.ListViewModel(query.ToList());

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


        public ActionResult Receipt(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var vehicle = db.Garages.Find(id);
            ReceiptViewModel model = new ReceiptViewModel();
            model = model.toViewModel(vehicle);
            return View(model);
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
