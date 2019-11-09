using BEFOYS.DataLayer.Entity.Supplier;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.ViewModels.Register.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Register.Step
{
   public class ViewStep1
    {
        public ViewStep1Haghighi Haghighi{ get; set; }
        public ViewStep1Hoghoghi Hoghoghi { get; set; }

        public string Website { get; set; }
        public ViewAddress[] Addresses { get; set; }
    }
    public class ViewStep1Haghighi
    {
        public string SR_NationalCode { get; set; }
        public string SR_ShenasnameID { get; set; }
        public DateTime? SR_Birthday { get; set; }
        public Enum_Gender? Gender { get; set; }
        public string Website { get; set; }
        public ViewAddress[] Addresses { get; set; }
        public ViewStep1Haghighi() { }
        public ViewStep1Haghighi(Tbl_SupplierReal model) {
            SR_NationalCode = model.SR_NationalCode;
            SR_ShenasnameID = model.SR_ShenasnameID;
            SR_Birthday = model.SR_Birthday;
            Gender = (Enum_Gender?)model.SR_GenderCodeID;
            Website = model.Supplier.Supplier_Website;
        
        }
    }
    public class ViewStep1Hoghoghi
    {
        public string SL_CompanyName { get; set; }
        public int? SL_CompanyTypeCodeID { get; set; }
        public string SL_CompanyTypeCodeGUID { get; set; }
        public string SL_SabtNumber { get; set; }
        public string SL_NationalCode { get; set; }
        public string SL_EconomicCode { get; set; }
        public bool? SL_HasAgent { get; set; }
        public string Website { get; set; }
        public ViewAddress[] Addresses { get; set; }
        public ViewStep1Hoghoghi() { }
        public ViewStep1Hoghoghi(Tbl_SupplierLegal model) {
            SL_CompanyName = model.SL_CompanyName;
            SL_NationalCode = model.SL_NationalCode;
            SL_EconomicCode = model.SL_EconomicCode;
            SL_SabtNumber = model.SL_SabtNumber;
            SL_HasAgent = model.SL_HasAgent;
            Website = model.Supplier.Supplier_Website;
            SL_CompanyTypeCodeID = model.SL_CompanyTypeCodeID;
        }
    }

}
