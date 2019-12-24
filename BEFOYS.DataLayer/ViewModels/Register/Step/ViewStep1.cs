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
        public Enum_UserType type { get; set; }
        public int StepNumber { get; set; }
        public Enum_Gender Gender { get; set; }
        public string Birthday { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UpdateInformation[] infoes { get; set; }
        public AddressValue[] Addresses{ get; set; }

    }
    public class AddressValue
    {
        public int index { get; set; }
        public string AddressIndex { get; set; }
        public string StateIndex { get; set; }
        public string StateName { get; set; }
        public string CityIndex{ get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public Phone[] phones { get; set; }
    }
    public class Phone
    {
        public string PhoneIndex { get; set; }
        public string PhoneValue { get; set; }
    }

}
