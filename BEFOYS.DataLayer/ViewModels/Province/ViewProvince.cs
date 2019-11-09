using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Province
{
    public class ViewProvince
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Display { get; set; }
        public int CityID { get; set; }
    }
}
