using BEFOYS.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panel.ViewModels.Account
{
    public class HaghighiViewModel
    {
        public Enum_UserType type { get; set; }
        public int StepNumber { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public Enum_Gender Gender { get; set; }
        public string BirthDay { get { return $"{Year}/{Month}/{Day}"; } }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public StepValuesViewModel[] infoes { get; set; }
        public AddressViewModel[] Addresses { get; set; }
    }
}
