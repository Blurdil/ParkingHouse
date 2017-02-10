using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingHouse.Models.Entity
{
    public class Garage
    {
        public int Id { get; set; }
        [Required]
        //[RegularExpression("^[A-Z]{3} [0-9]{0}$")]
        [Display(Name = "Registrerings nummer")]
        public string RegNr { get; set; }

        [StringLength(25)]
        [Required]
        [Display(Name = "Färg")]
        public string Color { get; set; }

        
        [Display(Name = "Antal hjul")]
        public int NumberOfTyres { get; set; }

        [Display(Name = "Parkering Startad")]
        public DateTime ParkingTimeStart { get; set; }


        [Required]
        [Display(Name = "Bil typ")]
        public string VehicleType { get; set; }

        [Required]
        [Display(Name = "Märke")]
        public string Fabricate { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string FabricateModel { get; set; }
    }
}