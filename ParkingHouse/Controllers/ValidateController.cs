using ParkingHouse.DAL;
using ParkingHouse.Helper;
using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingHouse.Controllers
{
    public class ValidateController : Controller
    {
        private parkingContext db = new parkingContext();
        private Guid _Id;
        public GarageInformation _garage;
        public ValidateController()
        {
            _Id = parkingHouseHelper.getGarageID();
            _garage = db.GarageInformation.Find(_Id);
        }

        public JsonResult CheckRegNr(string RegNr)
        {
            var check = _garage.Garages.Where(x => x.RegNr == RegNr).FirstOrDefault();
            if(check == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            string msg = string.Format("{0} är redan parkerad.", RegNr);
            return Json(msg, JsonRequestBehavior.AllowGet);

        }
    }
}