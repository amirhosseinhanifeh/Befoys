using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.ViewModels.Register.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Register.Step
{
    public class UpdateInformation
    {
        public int TypeCodeId { get; set; }
        public string Value { get; set; }
    }
    public class Step1
    {
        public Enum_Gender Gender { get; set; }
        public string Birthday { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UpdateInformation[] infoes { get; set; }
        
    }

}
