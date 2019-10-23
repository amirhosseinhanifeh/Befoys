using BEFOYS.DataLayer.Entity.Supplier;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Supplier
{
    public class ViewSupplierAgent
    {
        public string SLA_Name { get; set; }
        public string SLA_Family { get; set; }
        public string SLA_Mobile { get; set; }
        public string SLA_NationalCode { get; set; }
        public string SLA_ShenasnameID { get; set; }
        public int SLA_GenderCodeID { get; set; }
        public int SLA_TypeCodeID { get; set; }
        public ViewSupplierAgent() { }
        public ViewSupplierAgent(Tbl_SupplierLegalAgent model)
        {
            SLA_Family = model.SLA_Family;
            SLA_GenderCodeID = model.SLA_GenderCodeID;
            SLA_Mobile = model.SLA_Mobile;
            SLA_Name = model.SLA_Name;
            SLA_NationalCode = model.SLA_NationalCode;
            SLA_ShenasnameID = model.SLA_ShenasnameID;
        }
    }
}
