using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParkingHouse.Models.Entity;

namespace ParkingHouse.Models.ViewModels.ParkingHouse
{
    public class GarageIndexViewModel
    {
        public int Id { get; set; }
        public string RegNr { get; set; }
        public DateTime ParkingTimeStart { get; set; }
        public DateTime ParkingTimeStop { get; set; }
        public string Fabricate { get; set; }
        public string FabricateModel { get; set; }
        public IList<GarageIndexViewModel> Vehicles { get; set; }

        public List<GarageIndexViewModel> ListViewModel(List<Garage> vehicles)
        {
            List<GarageIndexViewModel> model = new List<GarageIndexViewModel>();
            foreach(var vehicle in vehicles)
            {
                GarageIndexViewModel v = new GarageIndexViewModel
                {
                    Id = vehicle.Id,
                    Fabricate = vehicle.Fabricate,
                    RegNr = vehicle.RegNr,
                    ParkingTimeStart = vehicle.ParkingTimeStart,
                    ParkingTimeStop = vehicle.ParkingTimeStop,
                    FabricateModel = vehicle.FabricateModel
                };
                model.Add(v);
            }
            return model;
        }
    }
}
