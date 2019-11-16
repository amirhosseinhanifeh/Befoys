using BEFOYS.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Account
{
    public class ViewLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Enum_VerificationType Type { get; set; }
    }
}
