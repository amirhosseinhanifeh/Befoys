using BEFOYS.DataLayer.Entity.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Role
{
    public class ViewBaseRole
    {
        public int? ID { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public ViewBaseRole() { }
        public ViewBaseRole(Tbl_BaseRole model)
        {
            ID = model.BR_ID;
            DisplayName = model.BR_Display;
            Name = model.BR_Name;
        }
    }
}
