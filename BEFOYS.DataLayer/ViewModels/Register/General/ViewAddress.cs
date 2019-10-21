using BEFOYS.DataLayer.Entity.Address;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Register.General
{
    public class ViewAddress
    {
        public string CityID { get; set; }
        public string Address { get; set; }
        public ViewPhone[] Phones { get; set; }
        public ViewAddress() { }
        public ViewAddress(Tbl_Address model)
        {
            CityID = model.City.City_GUID.ToString();
            Address = model.Address_Text;
            
        }
    }
}
