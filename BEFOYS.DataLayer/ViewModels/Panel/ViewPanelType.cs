using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Panel
{
   public class ViewPanelType
    {
        public int? ID { get; set; }
        public string NAME { get; set; }
        public string Display { get; set; }
        public bool ISFree { get; set; }
        public int? Price { get; set; }
    }
}
