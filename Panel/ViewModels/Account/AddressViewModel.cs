using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panel.ViewModels.Account
{
    public class AddressViewModel
    {
            public string StateName { get; set; }
            public string CityName { get; set; }
            public string Address { get; set; }
            public Phone[] phones { get; set; }
    }
    public class Phone
    {
        public string PhoneValue { get; set; }
    }
}
