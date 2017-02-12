using ParkingHouse.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.ViewModels.Page
{
    public class GarageDropDownViewModel
    {
        public Guid Value { get; set; }
        public string Name { get; set; }
        public IList<GarageDropDownViewModel> List { get; set; }

        public GarageDropDownViewModel toViewModel(List<GarageInformation> garages)
        {
            GarageDropDownViewModel model = new GarageDropDownViewModel();
            model.List = new List<GarageDropDownViewModel>();
            foreach(var garage in garages)
            {
                GarageDropDownViewModel m = new GarageDropDownViewModel();
                m.Value = garage.Id;
                m.Name = garage.ParkingHouseName;
                model.List.Add(m);
            }
            return model;
        }
    }
}