using System;

namespace ParkingHouse.Models.Entity
{
    public class PageInformation
    {
        public Guid id { get; set; }
        public string Url { get; set; }
        public string BannerPath { get; set; }
        public string InformationBlock { get; set; }
        public string ContactBlock { get; set; }
        public string BanerHeadLine { get; set; }
    }
}