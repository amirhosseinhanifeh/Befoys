using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.ViewModels.Register.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Register.Step
{
   public class ViewStep1
    {
        //Haghighi
        public string IdNumber { get; set; }
        public string PersonalCode { get; set; }
        public string BirthDay { get; set; }
        public Enum_Gender Gender { get; set; }

        //End 

        //Hoghoghi

        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string RegisteredNumber { get; set; }
        public string EconomicCode { get; set; }

        //

        public string Website { get; set; }
        public ViewAddress[] Addresses { get; set; }
    }
}
