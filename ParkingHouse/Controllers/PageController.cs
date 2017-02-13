using ParkingHouse.DAL;
using ParkingHouse.Helper;
using ParkingHouse.Models.Entity;
using ParkingHouse.Models.ViewModels.Home;
using ParkingHouse.Models.ViewModels.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingHouse.Controllers
{
    public class PageController : Controller
    {
        private parkingContext db = new parkingContext();
        private Guid _Id;
        public GarageInformation _garage;
        public PageController()
        {
            _Id = parkingHouseHelper.getGarageID();
            _garage = db.GarageInformation.Find(_Id);
        }

        public ActionResult Header()
        {
            HeaderViewModel model = new HeaderViewModel();
            model.NumberOfLots = parkingHouseHelper.numberOfParkingLots(_garage);
            var parkedCars = db.Garages.Where(x => x.GarageInformation.Id == _garage.Id).Count();
            model.FreeLots = parkingHouseHelper.numberOfParkingLots(_garage) - parkedCars;
            model.costHour = parkingHouseHelper.pricePerHour(_garage);
            model.ImagePath = _garage.page.BannerPath;
            model.BanerHeadLine = _garage.page.BanerHeadLine;
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult GarageDropDown()
        {
            var test = Session["GarageID"];
            GarageDropDownViewModel model = new GarageDropDownViewModel();
            var list = model.toViewModel(db.GarageInformation.OrderBy(x => x.ParkingHouseName).ToList());
            return View(list);
        }

        [ChildActionOnly]
        public ActionResult TextBlock()
        {
            TextBlockViewModel model = new TextBlockViewModel();
            model.TextBlock = _garage.page.InformationBlock;
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult ContactBlock()
        {
            ContactBlockViewModel model = new ContactBlockViewModel();
            model.ContactBlock = _garage.page.ContactBlock;
            return View(model);
        }

        public ActionResult ChangeID(string Id)
        {
            parkingHouseHelper.setGarageIDCookie(Id);
            return Json("Success");
        }
    }
}