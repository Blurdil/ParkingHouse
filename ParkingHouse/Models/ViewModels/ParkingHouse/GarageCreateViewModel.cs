using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.ViewModels.ParkingHouse
{
    public class GarageCreateViewModel
    {
        public int id { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public int NumberOfTyres { get; set; }
        public DateTime ParkingTimeStart { get; set; }
        public DateTime ParkingTimeStop { get; set; }
        public int Payed { get; set; }
        public VehicleType Types { get; set; }
        public string Fabricate { get; set; }
        public string FabricateModel { get; set; }

        public DateTime payedTime(int amount)
        {
            DateTime parkTime = DateTime.Now.AddMinutes(amount);
            return parkTime;
        }

        public enum VehicleType
        {
            Bil,
            Buss,
            Motorcykel,
            Lastbil
        }

        public Garage ToEntity(GarageCreateViewModel model)
        {
            var vehicle = new Garage
            {
                Id = model.id,
                Color = model.Color,
                RegNr = model.RegNr,
                NumberOfTyres = model.NumberOfTyres,
                ParkingTimeStart = DateTime.Now,
                ParkingTimeStop = model.payedTime(model.Payed),
                VehicleType = model.Types.ToString(),
                Fabricate = model.Fabricate,
                FabricateModel = model.FabricateModel
            };
            return vehicle;
        }

        public GarageCreateViewModel ToViewmodel(Garage model)
        {
            var vehicle = new GarageCreateViewModel
            {
                id = model.Id,
                Color = model.Color,
                RegNr = model.RegNr,
                NumberOfTyres = model.NumberOfTyres,
                ParkingTimeStart = model.ParkingTimeStart,
                ParkingTimeStop = model.ParkingTimeStop,
                Fabricate = model.Fabricate,
                FabricateModel = model.FabricateModel,
            };

            switch (model.VehicleType)
            {
                case "Motorcykel":
                    vehicle.Types = VehicleType.Motorcykel;
                    break;

                case "Buss":
                    vehicle.Types = VehicleType.Buss;
                    break;

                case "Lastbil":
                    vehicle.Types = VehicleType.Lastbil;
                    break;

                default:
                    vehicle.Types = VehicleType.Bil;
                    break;
              }  
            return vehicle;
        }
    }
}