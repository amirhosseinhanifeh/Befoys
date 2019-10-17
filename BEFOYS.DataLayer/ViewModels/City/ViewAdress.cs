using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.City
{
    public class ViewAdress
    {
        public int? Address_ID { get; set; }
        public Guid Address_GUID { get; set; }
        public string Address_Text { get; set; }
        public int? Address_CityID { get; set; }
        public bool Address_ISSetGPS { get; set; }
        public string Address_GPSLat { get; set; }
        public string Address_GPSLong { get; set; }
        public int Address_TypeCodeID { get; set; }
    }
}
