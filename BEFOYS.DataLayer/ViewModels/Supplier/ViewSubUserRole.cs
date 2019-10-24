using BEFOYS.DataLayer.Entity.SubUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Supplier
{
    public class ViewSubUserRole
    {
        public int? ID { get; set; }
        public string SUR_Name { get; set; }
        public string SUR_Display { get; set; }
        public ViewSubUserRole() { }
        public ViewSubUserRole(Tbl_SubUserRole model)
        {
            ID = model.SUR_ID;
            SUR_Name = model.SUR_Name;
            SUR_Display = model.SUR_Display;
        }
    }
}
