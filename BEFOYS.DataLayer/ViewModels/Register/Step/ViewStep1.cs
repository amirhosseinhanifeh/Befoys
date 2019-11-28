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
    }

}
