using ParkingHouse.Helper;
using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.ViewModels.ParkingHouse
{
    public class GarageCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Registrerings Nummer")]
        [RegularExpression("^[A-Z]{3} [0-9]{3}", ErrorMessage = "Måste vara av format AAA 111")]
        public string RegNr { get; set; }

        [Display(Name ="Färg")]
        [Required]
        public string Color { get; set; }
        public int NumberOfTyres { get; set; }
        public DateTime ParkingTimeStart { get; set; }
        public int Payed { get; set; }
        [Display(Name = "Typ av fordon")]
        public VehicleType Types { get; set; }
        [Required]
        [Display(Name ="Märke")]
        public string Fabricate { get; set; }
        [Required]
        [Display(Name ="Model")]
        public string FabricateModel { get; set; }
        [Display(Name = "Parkerings tid")]
        public string Duration { get; set; }
        [Display(Name = "Kostnad")]
        public int Cost { get; set; }

        public DateTime payedTime(int amount)
        {
            DateTime parkTime = DateTime.Now.AddMinutes(amount);
            return parkTime;
        }

        public int getNumberOfTyres(GarageCreateViewModel vehicle)
        {
            int numberOfTyres = 0;
            switch(vehicle.Types.ToString().ToLower())
            {
                case "motorcykel":
                    numberOfTyres = 2;
                    break;

                case "buss":
                    numberOfTyres = 6;
                    break;

                case "lastbil":
                    numberOfTyres = 8;
                    break;

                default:
                    numberOfTyres = 4;
                    break;
            }
            return numberOfTyres;
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
                NumberOfTyres = getNumberOfTyres(model),
                ParkingTimeStart = DateTime.Now,
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
                Fabricate = model.Fabricate,
                FabricateModel = model.FabricateModel,
                Duration = parkingHouseHelper.duration(model.ParkingTimeStart),
                Cost = parkingHouseHelper.getPrice(model.ParkingTimeStart),
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