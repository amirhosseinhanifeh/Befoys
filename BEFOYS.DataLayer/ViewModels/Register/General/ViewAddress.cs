using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Register.General
{
    public class ViewAddress
    {
        public Guid CityID { get; set; }
        public string Address { get; set; }
        public ViewPhone[] Phones { get; set; }
    }
}
