using BEFOYS.DataLayer.Entity.Code;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Code
{
    public class ViewCode
    {
        public int? ID { get; set; }
        public int Code_CGID { get; set; }
        public string Code_Name { get; set; }
        public string Code_Display { get; set; }
        public ViewCode() { }
        public ViewCode(Tbl_Code model)
        {
            Code_CGID = model.Code_CGID;
            Code_Display = model.Code_Display;
            Code_Name = model.Code_Name;
            ID = model.Code_ID;
        }
    }
}
