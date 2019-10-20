using BEFOYS.DataLayer.Entity.Code;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Code
{
    public class ViewCodeGroup
    {
        public int? ID { get; set; }
        public string CG_Name { get; set; }
        public string CG_Display { get; set; }
        public ViewCodeGroup() { }
        public ViewCodeGroup(Tbl_CodeGroup model)
        {
            CG_Display = model.CG_Display;
            CG_Name = model.CG_Name;
            ID = model.CG_ID;
        }
    }
}
